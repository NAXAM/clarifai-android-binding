using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.Support.V7.Widget;
using Clarifai2.Dto.Prediction;

namespace clarifi
{
    class ConceptsAdapter : RecyclerView.Adapter
    {
        IList<Concept> concepts;

        public override int ItemCount => concepts?.Count ?? 0;

        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            var vh = (ConceptViewHolder)holder;
            vh.Bind(concepts[position]);
        }

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            var itemView = LayoutInflater.FromContext(parent.Context)
                                        .Inflate(Resource.Layout.item_concept, parent, false);

            return new ConceptViewHolder(itemView);
        }

        public void SetData(IEnumerable<Concept> concepts) {
            this.concepts = concepts.ToList();
            System.Diagnostics.Debug.WriteLine("thaohandsome: "+concepts.Count());
            NotifyDataSetChanged();
        }
    }

    class ConceptViewHolder : RecyclerView.ViewHolder
    {
        TextView label;
        TextView probability;

        public ConceptViewHolder(View itemView) : base(itemView)
        {
            label = itemView.FindViewById<TextView>(Resource.Id.label);
            probability = itemView.FindViewById<TextView>(Resource.Id.probability);
        }

        public void Bind(Concept concept) {

            label.Text = string.IsNullOrWhiteSpace(concept.Name()) ? "Concept.Id()" : concept.Name();
            probability.Text = concept.Value().ToString();
        }
    }
}