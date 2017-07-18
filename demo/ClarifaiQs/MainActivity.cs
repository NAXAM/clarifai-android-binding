using Android.App;
using System.Diagnostics;
using Android.Widget;
using Android.OS;
using Clarifai2.Api;
using Clarifai2.Api.Request;
using Java.Lang;
using System;
using Java.IO;
using Android.Content;
using Clarifai2.Dto.Input;
using Clarifai2.Api.Request.Concept;
using Clarifai2.Api.Request.Feedback;
using Clarifai2.Api.Request.Input;
using Clarifai2.Api.Request.Model;
using Clarifai2.Dto.Model;
using System.Collections.Generic;
using Google.Gson;
using System.Collections.Generic;
using Clarifai2.Dto.Prediction;
using Clarifai2.Dto.Model.Output;
using Android.Runtime;
using Clarifai2.Dto;
using Java.Util;
using System.Collections;
using System.Threading.Tasks;
using System.Linq;
using Android.Support.V7.App;
using Android.Support.V7.Widget;
using Android.Graphics;
using Java.Net;
using Android.Support.Design.Widget;
using clarifi;

namespace ClarifaiQs
{
    [Activity(Label = "ClarifaiQs", MainLauncher = true, Icon = "@mipmap/ic_launcher", Theme = "@style/AppTheme")]
    public class MainActivity : AppCompatActivity
    {
        //int count = 1;
        FloatingActionButton fab;
        public static int PICK_IMAGE = 100;

        ImageView imgShow;
        IClarifaiClient client;
        RecyclerView resultsList;
        ConceptsAdapter conceptsAdapter;

      

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_recognize);

            fab = FindViewById<FloatingActionButton>(Resource.Id.fab);
            fab.Click += (s, e) =>
            {
                Toast.MakeText(this, "Choosing picture", ToastLength.Long).Show();
                StartActivityForResult(new Intent(Intent.ActionPick).SetType("image/*"), PICK_IMAGE);

            };

            imgShow = FindViewById<ImageView>(Resource.Id.image);
            conceptsAdapter = new ConceptsAdapter();
            resultsList = FindViewById<RecyclerView>(Resource.Id.resultsList);
            resultsList.SetLayoutManager(new LinearLayoutManager(this));
            resultsList.SetAdapter(conceptsAdapter);

            client = new ClarifaiBuilder("e995372b2d2b4225a82c52741a60a540").BuildSync();// adding api key here

            // Get our button from the layout resource,
            // and attach an event to it
            //Button button = FindViewById<Button>(Resource.Id.myButton);

            //button.Click += delegate { button.Text = $"{count++} clicks!"; };
        }


        protected override void OnActivityResult(int requestCode, [GeneratedEnum] Result resultCode, Intent data)
        {
            if (resultCode != Result.Ok)
            {

                return;
            }
            switch (requestCode)
            {
                case 100:
                    imgShow.SetImageURI(data.Data);
                    byte[] imageBytes = ClarifaiUtil.retrieveSelectedImage(this, data);
                    if (imageBytes != null)
                    {
                        Task.Run(() =>
                        {
                            ExecuteClarifai(imageBytes);
                        });
                    }

                    break;
            }
        }

        private void ExecuteClarifai(byte[] imageBytes)
        {

            var generalModel = client.DefaultModels.GeneralModel();
            var response = generalModel
                .Predict()
                .WithInputs(ClarifaiInput.ForImage(ClarifaiImage.Of(imageBytes)))
                .ExecuteSync();


            if (!response.IsSuccessful)
            {
                return;
            }

            var predictions = (Java.Util.ArrayList)response.Get();

            if (predictions.IsEmpty)
            {
                return;
            }

            var clarifaiOutput = (ClarifaiOutput)predictions.Get(0);

            var data = clarifaiOutput.Data();

            RunOnUiThread(() => {
                conceptsAdapter.SetData(data.Cast<Concept>());
            });
        }
    }
}

