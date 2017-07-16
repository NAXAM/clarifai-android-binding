using System;
using System.Collections.Generic;
using Android.Runtime;

namespace Clarifai2.Dto.Model
{
    partial class ClusterModel
    {
        public override Clarifai2.Dto.Model.Output_info.OutputInfo OutputInfo()
        {
            return ClusterOutputInfo();
        }
    }

    partial class ColorModel
    {
        public override Clarifai2.Dto.Model.Output_info.OutputInfo OutputInfo()
        {
            return ColorOutputInfo();
        }
    }
    partial class ConceptModel
    {
        public override Clarifai2.Dto.Model.Output_info.OutputInfo OutputInfo()
        {
            return ConceptOutputInfo();
        }
    }

    partial class DemographicsModel
    {
        public override Clarifai2.Dto.Model.Output_info.OutputInfo OutputInfo()
        {
            return DemographicsOutputInfo();
        }
    }
    partial class EmbeddingModel
    {
        public override Clarifai2.Dto.Model.Output_info.OutputInfo OutputInfo()
        {
            return EmbeddingOutputInfo();
        }
    }
    partial class FaceDetectionModel
    {
        public override Clarifai2.Dto.Model.Output_info.OutputInfo OutputInfo()
        {
            return FaceDetectionOutputInfo();
        }
    }
    partial class FocusModel
    {
        public override Clarifai2.Dto.Model.Output_info.OutputInfo OutputInfo()
        {
            return FocusOutputInfo();
        }
    }
    partial class LogoModel
    {
        public override Clarifai2.Dto.Model.Output_info.OutputInfo OutputInfo()
        {
            return LogoOutputInfo();
        }
    }
    partial class UnknownModel
    {
        public override Clarifai2.Dto.Model.Output_info.OutputInfo OutputInfo()
        {
            return UnknownOutputInfo();
        }
    }
}

namespace Clarifai2.Api
{
    partial class ClarifaiResponse
    {
        partial class Failure
        {
            protected override Java.Lang.Object RawOrNull
            {
                get
                {
                    return OrNull;
                }
            }
        }
        partial class MixedSuccess
        {
            protected override Java.Lang.Object RawOrNull
            {
                get
                {
                    return OrNull;
                }
            }
        }
        partial class NetworkError
        {
            protected override Java.Lang.Object RawOrNull
            {
                get
                {
                    return OrNull;
                }
            }
        }
        partial class Successful
        {
            protected override Java.Lang.Object RawOrNull
            {
                get
                {
                    return OrNull;
                }
            }
        }
    }
}

namespace Clarifai2.Api.Request
{
    partial class ClarifaiRequestAdapter : Clarifai2.Api.Request.IClarifaiRequest
    {
        public abstract Clarifai2.Api.ClarifaiResponse ExecuteSync();
    }
}