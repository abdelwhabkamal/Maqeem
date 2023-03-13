using Microsoft.ML.Trainers.FastTree;
using Microsoft.ML;

namespace ConsoleApp4
{
    public partial class MLModel1
    {
        public static ITransformer RetrainPipeline(MLContext context, IDataView trainData)
        {
            var pipeline = BuildPipeline(context);
            var model = pipeline.Fit(trainData);

            return model;
        }

        public static IEstimator<ITransformer> BuildPipeline(MLContext mlContext)
        {
            // Data process configuration with pipeline data transformations
            var pipeline = mlContext.Transforms.Categorical.OneHotEncoding(@"city", @"city")      
                                    .Append(mlContext.Transforms.ReplaceMissingValues(new []{new InputOutputColumnPair(@"type", @"type"),new InputOutputColumnPair(@"area", @"area"),new InputOutputColumnPair(@"bedrooms", @"bedrooms"),new InputOutputColumnPair(@"bathrooms", @"bathrooms"),new InputOutputColumnPair(@"level", @"level"),new InputOutputColumnPair(@"furnished", @"furnished"),new InputOutputColumnPair(@"rent", @"rent"),new InputOutputColumnPair(@"region", @"region")}))      
                                    .Append(mlContext.Transforms.Concatenate(@"Features", new []{@"city",@"type",@"area",@"bedrooms",@"bathrooms",@"level",@"furnished",@"rent",@"region"}))      
                                    .Append(mlContext.Transforms.NormalizeMinMax(@"Features", @"Features"))      
                                    .Append(mlContext.Regression.Trainers.FastTreeTweedie(new FastTreeTweedieTrainer.Options(){NumberOfLeaves=17,MinimumExampleCountPerLeaf=3,NumberOfTrees=84,MaximumBinCountPerFeature=64,LearningRate=1F,FeatureFraction=1F,LabelColumnName=@"price",FeatureColumnName=@"Features"}));

            return pipeline;
        }
    }
}
