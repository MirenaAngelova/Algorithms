using System;
using System.Collections.Generic;

namespace _08.Supplement_Graph_to_Make_It_Strongly_Connected
{
    public class SupplementGraphToMakeItSC
    {
        private const int ResultNotFound = -1;


        private static int verticesCount;
        private static int[] operationStack;
        private static bool[] visitedVertices;

        private static List<Vertex> vertices;
        private static List<ConnectedComponent> connectedComponents;

        private static int[] vertexSccIndices;
        private static SccEdge[] matchingSccEdges;
        private static SccEdge[] leftoverSccEdges;
        private static SccEdge[] sccEdgesToAdd;
        private static bool[] visitedScc;

        private static int predCount;
        private static int descCount;
        private static int sccMembersCount;
        private static int stackSize;
        private static int sccCount;
        private static int matchingSccEdgesCount;
        private static int leftoverSccEdgesCount;
        private static int sccEdgesToAddCount;

        public static void Main()
        {
            ProcessInput();
            FindSCC();
            PrintEdgesToAdd();
            PrintSCC();
            PrintGraph();
        }

        private static void PrintGraph()
        {
            for (int index = 0; index < verticesCount; ++index)
            {
                Console.WriteLine($"Vertex: {index}");
                Console.WriteLine(" Parents: ");
                predCount = vertices[index].PredecessorsCount;
                for (int pI = 0; pI < predCount; pI++)
                {
                    Console.WriteLine($"{vertices[index].Predecessors[pI]} ");
                }

                Console.WriteLine(" Child: ");
                descCount = vertices[index].DescendantsCount;
                for (int dI = 0; dI < descCount; dI++)
                {
                    Console.WriteLine($"{vertices[index].Descendants[dI]} ");
                }

                Console.WriteLine();
            }
        }

        private static void PrintSCC()
        {
            for (int index = 0; index < sccCount; ++index)
            {
                Console.WriteLine($"SCC {index} : ");
                sccMembersCount = connectedComponents[index].MembersCount;
                for (int membIndex = 0; membIndex < sccMembersCount; membIndex++)
                {
                    Console.WriteLine($"{connectedComponents[index].Members[membIndex]} ");
                }

                Console.WriteLine();
            }
        }

        private static void PrintEdgesToAdd()
        {
            for (int index = 0; index < sccEdgesToAddCount; ++index)
            {
                SccEdge currentEdge = sccEdgesToAdd[index];
                ConnectedComponent parent = connectedComponents[currentEdge.ParentScc];
                ConnectedComponent child = connectedComponents[currentEdge.ChildScc];
                Console.WriteLine($"{parent.Members[0]} -> {child.Members[0]}{Environment.NewLine}");
            }
        }

        private static void FindSCC()
        {
            for (int i = 0; i < verticesCount; i++)
            {
                if (!visitedVertices[i])
                {
                    AddElementsToOperationStack(i);
                }
            }

            ClearVisitedVertices();

            for (int stackIndex = stackSize - 1; stackIndex >= 0; --stackIndex)
            {
                int vertexIndex = operationStack[stackIndex];
                if (!visitedVertices[vertexIndex])
                {
                    ConnectSCC(vertexIndex);
                    sccCount++;
                }
            }

            AddMinSccEdges();
        }

        private static void AddMinSccEdges()
        {
            bool hasConnected = ConnectIslands();
            int upperBound = matchingSccEdgesCount;

            if (hasConnected)
            {
                --upperBound;
            }

            for (int sccEdgeIndex = 0; sccEdgeIndex < upperBound; ++sccEdgeIndex)
            {
                SccEdge currentEdge = matchingSccEdges[sccEdgeIndex];
                SccEdge nextEdge = matchingSccEdges[(sccEdgeIndex + 1) % matchingSccEdgesCount];

                sccEdgesToAdd[sccEdgesToAddCount].ParentScc = currentEdge.ChildScc;
                sccEdgesToAdd[sccEdgesToAddCount].ChildScc = nextEdge.ParentScc;
                ++sccEdgesToAddCount;
            }

            ConnectLeftoverComponents();
        }

        private static void ConnectLeftoverComponents()
        {
            int[] leftoverSources = new int[leftoverSccEdgesCount];
            int[] leftoverSinks = new int[leftoverSccEdgesCount];
            int leftoverSourcesCount = 0;
            int leftoverSinksCount = 0;
            int index;

            for (index = 0; index < leftoverSccEdgesCount; ++index)
            {
                SccEdge currentEdge = leftoverSccEdges[index];
                if (!visitedScc[currentEdge.ParentScc])
                {
                    leftoverSources[leftoverSourcesCount] = currentEdge.ParentScc;
                    ++leftoverSourcesCount;
                    visitedScc[currentEdge.ParentScc] = true;
                }
                else if (!visitedScc[currentEdge.ChildScc])
                {
                    leftoverSinks[leftoverSinksCount] = currentEdge.ChildScc;
                    ++leftoverSinksCount;
                    visitedScc[currentEdge.ChildScc] = true;
                }
            }

            for (index = 0; index < Math.Min(leftoverSourcesCount, leftoverSinksCount); index++)
            {
                sccEdgesToAdd[sccEdgesToAddCount].ParentScc = leftoverSinks[index];
                sccEdgesToAdd[sccEdgesToAddCount].ChildScc = leftoverSources[index];
                ++sccEdgesToAddCount;
            }

            for (index = Math.Min(leftoverSourcesCount, leftoverSinksCount);
                 index < Math.Max(leftoverSourcesCount, leftoverSinksCount);
                 ++index)
            {
                int connectedSccIndex = matchingSccEdges[0].ParentScc;

                if (leftoverSinksCount > index)
                {
                    sccEdgesToAdd[sccEdgesToAddCount].ParentScc = leftoverSinks[index];
                    sccEdgesToAdd[sccEdgesToAddCount].ChildScc = connectedSccIndex;
                    ++sccEdgesToAddCount;
                }
                else
                {
                    sccEdgesToAdd[sccEdgesToAddCount].ParentScc = connectedSccIndex;
                    sccEdgesToAdd[sccEdgesToAddCount].ChildScc = leftoverSources[index];
                    ++sccEdgesToAddCount;
                }
            }
        }

        private static bool ConnectIslands()
        {
            for (int index = 0; index < sccCount; ++index)
            {
                if (!visitedScc[index])
                {
                    if (matchingSccEdgesCount >= 1)
                    {
                        SccEdge currentEdge = matchingSccEdges[matchingSccEdgesCount - 1];
                        SccEdge nextEdge = matchingSccEdges[0];

                        sccEdgesToAdd[sccEdgesToAddCount].ParentScc = currentEdge.ChildScc;
                        sccEdgesToAdd[sccEdgesToAddCount].ChildScc = index;
                        ++sccEdgesToAddCount;

                        sccEdgesToAdd[sccEdgesToAddCount].ParentScc = index;
                        sccEdgesToAdd[sccEdgesToAddCount].ChildScc = nextEdge.ParentScc;
                        ++sccEdgesToAddCount;

                        return true;
                    }
                    else
                    {
                        int connectedSccIndex = FindFirstFreeSCC();

                        sccEdgesToAdd[sccEdgesToAddCount].ParentScc = connectedSccIndex;
                        sccEdgesToAdd[sccEdgesToAddCount].ChildScc = index;
                        ++sccEdgesToAddCount;

                        sccEdgesToAdd[sccEdgesToAddCount].ParentScc = index;
                        sccEdgesToAdd[sccEdgesToAddCount].ChildScc = connectedSccIndex;
                        ++sccEdgesToAddCount;
                    }
                }
            }

            return false;
        }

        private static int FindFirstFreeSCC()
        {
            for (int index = 0; index < sccCount; ++index)
            {
                if (visitedScc[index])
                {
                    return index;
                }
            }

            return ResultNotFound;
        }

        private static void ConnectSCC(int vertexIndex)
        {
            Vertex vertex = vertices[vertexIndex];
            visitedVertices[vertexIndex] = true;
            predCount = vertices[vertexIndex].PredecessorsCount;

            for (int prevIndex = 0; prevIndex < predCount; ++prevIndex)
            {
                int nextVertexIndex = vertex.Predecessors[prevIndex];
                if (!visitedVertices[nextVertexIndex])
                {
                    ConnectSCC(nextVertexIndex);
                }
                else if (vertexSccIndices[nextVertexIndex] != ResultNotFound) // Sink SCC found
                {
                    if (!visitedScc[vertexSccIndices[nextVertexIndex]] && !visitedScc[sccCount])
                    {
                        matchingSccEdges[matchingSccEdgesCount].ParentScc = vertexSccIndices[nextVertexIndex];
                        matchingSccEdges[matchingSccEdgesCount].ChildScc = sccCount;
                        ++matchingSccEdgesCount;

                        visitedScc[vertexSccIndices[nextVertexIndex]] = true;
                        visitedScc[sccCount] = true;
                    }
                    else
                    {
                        leftoverSccEdges[leftoverSccEdgesCount].ParentScc = vertexSccIndices[nextVertexIndex];
                        leftoverSccEdges[leftoverSccEdgesCount].ChildScc = sccCount;
                        ++leftoverSccEdgesCount;
                    }
                }
            }

            sccMembersCount = connectedComponents[sccCount].MembersCount;
            connectedComponents[sccCount].Members[sccMembersCount] = vertexIndex;
            sccMembersCount++;
            vertexSccIndices[vertexIndex] = sccCount;
        }

        private static void AddElementsToOperationStack(int vertexIndex)
        {
            Vertex vertex = vertices[vertexIndex];
            visitedVertices[vertexIndex] = true;
            descCount = vertices[vertexIndex].DescendantsCount;

            for (int descIndex = 0; descIndex < descCount; descIndex++)
            {
                int nextVertexIndex = vertex.Descendants[descIndex];
                if (!visitedVertices[nextVertexIndex])
                {
                    AddElementsToOperationStack(nextVertexIndex);
                }
            }

            operationStack[stackSize++] = vertexIndex;
        }

        private static void ProcessInput()
        {
            verticesCount = int.Parse(Console.ReadLine().Substring(7));
            int edgesCount = int.Parse(Console.ReadLine().Substring(7));

            InitializeResources();

            int vertexIndex = 0;
            predCount = vertices[vertexIndex].PredecessorsCount;
            descCount = vertices[vertexIndex].DescendantsCount;

            for (int i = 0; i < edgesCount; i++)
            {
                string[] parameters = Console.ReadLine()
                    .Split(new[] { ' ', '-', '>' }, StringSplitOptions.RemoveEmptyEntries);
                int parent = int.Parse(parameters[0]);
                int child = int.Parse(parameters[1]);

                vertices[parent].Descendants[descCount] = child;
                vertices[child].Predecessors[predCount] = parent;
                descCount++;
                predCount++;
            }
        }

        private static void InitializeResources()
        {
            operationStack = new int[verticesCount];
            visitedVertices = new bool[verticesCount];
            vertices = new List<Vertex>();
            connectedComponents = new List<ConnectedComponent>();

            vertexSccIndices = new int[verticesCount];
            matchingSccEdges = new SccEdge[verticesCount];
            leftoverSccEdges = new SccEdge[verticesCount];
            sccEdgesToAdd = new SccEdge[verticesCount];
            visitedScc = new bool[verticesCount];
            visitedVertices = new bool[verticesCount];
            ClearVisitedVertices();
            InitializeSCCs();

            for (int i = 0; i < verticesCount; i++)
            {
                vertices[i].Predecessors = new List<int>(verticesCount);
                vertices[i].Descendants = new List<int>(verticesCount);
                vertices[i].PredecessorsCount = 0;
                vertices[i].DescendantsCount = 0;
                vertexSccIndices[i] = ResultNotFound;
            }
        }

        private static void InitializeSCCs()
        {

            for (int i = 0; i < verticesCount; i++)
            {
                connectedComponents[i].Members = new List<int>();
                connectedComponents[i].MembersCount = 0;
            }
        }

        private static void ClearVisitedVertices()
        {
            for (int i = 0; i < verticesCount; i++)
            {
                visitedVertices[i] = false;
            }
        }
    }
}
