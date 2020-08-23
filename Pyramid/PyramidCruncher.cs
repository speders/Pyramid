using System.Collections.Generic;
using System.Linq;

namespace Pyramid
{
    class PyramidCruncher
    {
        public List<PyramidNode> FoundPaths { get; set; } = new List<PyramidNode>();

        public int MaxValue => FoundPaths.Max(x => x.Total);

        public string MaxPath => FoundPaths.First(x => x.Total == MaxValue).Path;

        public bool Crunch(int[][] pyramid)
        {
            var pyramidNode = BuildPyramidStructure(pyramid);
            FindMaxPath(pyramidNode);
            if (FoundPaths.Count > 0)
                return true;

            return false;
        }

        private PyramidNode BuildPyramidStructure(int[][] pyramid)
        {
            PyramidNode[][] pyramidNodes = new PyramidNode[pyramid.Length][];

            // We build the nodes
            for (int i = 0; i < pyramid.Length; i++)
            {
                pyramidNodes[i] = new PyramidNode[pyramid[i].Length];
                for (int j = 0; j < pyramid[i].Length; j++)
                {
                    pyramidNodes[i][j] = new PyramidNode(pyramid[i][j]);
                }
            }

            // We tie them together (based on original structure)
            for (int i = 0; i < pyramid.Length - 1; i++)    // We doen't go all the way to the bottom, the values are caught in the line before
            {
                for (int j = 0; j < pyramid[i].Length; j++)
                {
                    pyramidNodes[i][j].Children = new PyramidNode[] { pyramidNodes[i + 1][j], pyramidNodes[i + 1][j + 1] }; // Catching PyramidsNodes a level below
                }
            }

            return pyramidNodes[0][0];  // TopNode
        }

        private void FindMaxPath(PyramidNode pyramidNode)
        {
            if (pyramidNode.Children == null)   // We are at the end - store the result
            {
                FoundPaths.Add(new PyramidNode(pyramidNode.Value) { Path = pyramidNode.Path, Total = pyramidNode.Total });
            }
            else
            {
                foreach (var pyramidNodeChild in pyramidNode.Children)
                {
                    if (pyramidNode.Value % 2 == 0) // We have equal and are looking for odd
                    {
                        if (pyramidNodeChild.Value % 2 == 0)
                            continue;
                    }
                    else
                    {   // Odd                    
                        if (pyramidNodeChild.Value % 2 != 0) // Also odd                    
                            continue;
                    }

                    if (pyramidNode.Path == null)
                    {
                        pyramidNode.Total = pyramidNode.Value;
                        pyramidNode.Path = pyramidNode.Value.ToString();
                    }

                    pyramidNodeChild.Total = pyramidNode.Total + pyramidNodeChild.Value;
                    pyramidNodeChild.Path = $"{pyramidNode.Path};{pyramidNodeChild.Value}";
                    FindMaxPath(pyramidNodeChild);
                }
            }
        }
    }
}
