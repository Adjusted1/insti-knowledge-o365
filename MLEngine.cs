using System;
//using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.DataView;
using Microsoft.ML;
using Microsoft.ML.Data;
using Accord.MachineLearning;
using EnglishStemmer;
using Accord.Math.Distances;

namespace blazor_base
{
    /// <summary>Indicates whether the specified array is null or has a length of zero.</summary>
    /// <param name="array">The array to test.</param>
    /// <returns>true if the array parameter is null or has a length of zero; otherwise, false.</returns>
    public static class ChkForNullArr
    {
        public static bool IsNullOrEmpty(this Array array)
        {
            return (array == null || array.Length == 0);
        }
    }
    public class MLengine
    {
        public int[] Labels { get; set; }
        public MLengine() { }
        public void Engine(double[][] observations, int k, ref int[] labels)
        {
            Accord.Math.Random.Generator.Seed = 0;
            KMeans kmeans = new KMeans(k);
            kmeans.UseSeeding = Seeding.Uniform;
            kmeans.MaxIterations = 0; // no limit
            KMeansClusterCollection clusters = kmeans.Learn(observations);
            double[][] centroids = kmeans.Centroids;
            labels = clusters.Decide(observations);
            double err = kmeans.Error;
        }
        private static T[,] To2D<T>(T[][] source)
        {
            try
            {
                int FirstDim = source.Length;
                int SecondDim = source.GroupBy(row => row.Length).Single().Key; // throws InvalidOperationException if source is not rectangular

                var result = new T[FirstDim, SecondDim];
                for (int i = 0; i < FirstDim; ++i)
                    for (int j = 0; j < SecondDim; ++j)
                        result[i, j] = source[i][j];

                return result;
            }
            catch (InvalidOperationException)
            {
                throw new InvalidOperationException("The given jagged array is not rectangular.");
            }
        }
        // http://www.alglib.net AHC hierarchical clustering implementation
        //public void AHC(double[][] observations, int k)
        //{
        //    // *** todo:
        //    // *** 
        //    // ***      move Hierarchichal kmeans to separate method
        //    // ***
        //    // ***
        //    //
        //    // The very simple clusterization example
        //    //
        //    // We have a set of points in 2D space:
        //    //     (P0,P1,P2,P3,P4) = ((1,1),(1,2),(4,1),(2,3),(4,1.5))
        //    //
        //    //  |
        //    //  |     P3
        //    //  |
        //    //  | P1          
        //    //  |             P4
        //    //  | P0          P2
        //    //  |-------------------------
        //    //
        //    // We want to perform Agglomerative Hierarchic Clusterization (AHC),
        //    // using complete linkage (default algorithm) and Euclidean distance
        //    // (default metric).
        //    //
        //    // In order to do that, we:
        //    // * create clusterizer with clusterizercreate()
        //    // * set points XY and metric (2=Euclidean) with clusterizersetpoints()
        //    // * run AHC algorithm with clusterizerrunahc
        //    //
        //    // You may see that clusterization itself is a minor part of the example,
        //    // most of which is dominated by comments :)
        //    //
        //    alglib.clusterizerstate s;


        //    //alglib.ahcreport rep;

        //    alglib.kmeansreport kmrep;

        //    //observations = StripNulls(observations);

        //    double[,] xy = To2D(observations);

        //    //var newArray = Array.ConvertAll(xy, item => (Array)item);
        //    alglib.clusterizercreate(out s);
        //    alglib.clusterizersetpoints(s, xy, 2);
        //    alglib.clusterizerrunkmeans(s, k, out kmrep);
        //    //alglib.clusterizerrunahc(s, out rep);
        //    //kmeans
        //    int[] labels = kmrep.cidx;
        //}

    }
}
