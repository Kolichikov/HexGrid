using HexGridStandard;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace HexGridStandardTests
{
    public class HexGridTests
    {
        [TestCaseSource(nameof(RingTests))]
        public void OnRingReturnsProperResultsWithCubeCoordinates((Vector3 centre, Vector3 inTest, int radius, bool expectedOutput) input)
        {
            var grid = new HexGrid<CubeCoordinate>();
            var cc=  new CubeCoordinate(input.centre);
            var ct = new CubeCoordinate(input.inTest);
            Assert.AreEqual(input.expectedOutput, grid.OnRing(ct, input.radius, cc));
        }

        static IEnumerable<(Vector3 centre, Vector3 inTest, int radius, bool expectedOutput)> RingTests
        {
            get {
                #region ring level 1 test cases around origin
                yield return (new Vector3(0,0,0), new Vector3(0,0,0), 1, false);

                yield return (new Vector3(0,0,0), new Vector3(0,1,-1), 1, true);
                yield return (new Vector3(0,0,0), new Vector3(1,0,-1), 1, true);
                yield return (new Vector3(0,0,0), new Vector3(1,-1,0), 1, true);
                yield return (new Vector3(0,0,0), new Vector3(0,-1,1), 1, true);
                yield return (new Vector3(0,0,0), new Vector3(-1,0,1), 1, true);
                yield return (new Vector3(0,0,0), new Vector3(-1,1,0), 1, true);

                yield return (new Vector3(0,0,0), new Vector3(0,1,-1), 2, false);
                yield return (new Vector3(0,0,0), new Vector3(1,0,-1), 2, false);
                yield return (new Vector3(0,0,0), new Vector3(1,-1,0), 2, false);
                yield return (new Vector3(0,0,0), new Vector3(0,-1,1), 2, false);
                yield return (new Vector3(0,0,0), new Vector3(-1,0,1), 2, false);
                yield return (new Vector3(0,0,0), new Vector3(-1,1,0), 2, false);

                yield return (new Vector3(0,0,0), new Vector3(0,2,-2), 1, false);
                yield return (new Vector3(0,0,0), new Vector3(2,1,-3), 1, false);
                yield return (new Vector3(0,0,0), new Vector3(1,2,-3), 1, false);
                yield return (new Vector3(0,0,0), new Vector3(0,-2,2), 1, false);
                yield return (new Vector3(0,0,0), new Vector3(1,1,-2), 1, false);
                #endregion
                #region ring level 2 test cases around origin
                yield return (new Vector3(0,0,0), new Vector3(0,2,-2), 2, true);
                yield return (new Vector3(0,0,0), new Vector3(2,0,-2), 2, true);
                yield return (new Vector3(0,0,0), new Vector3(2,-2,0), 2, true);
                yield return (new Vector3(0,0,0), new Vector3(0,-2,2), 2, true);
                yield return (new Vector3(0,0,0), new Vector3(-2,0,2), 2, true);
                yield return (new Vector3(0,0,0), new Vector3(-2,2,0), 2, true);

                yield return (new Vector3(0,0,0), new Vector3(1,1,-2), 2, true);
                yield return (new Vector3(0,0,0), new Vector3(-2,1,1), 2, true);
                yield return (new Vector3(0,0,0), new Vector3(1,-2,1), 2, true);
                yield return (new Vector3(0,0,0), new Vector3(-1,-1,2), 2, true);
                yield return (new Vector3(0,0,0), new Vector3(2,-1,-1), 2, true);
                yield return (new Vector3(0,0,0), new Vector3(-1,2,-1), 2, true);

                yield return (new Vector3(0,0,0), new Vector3(0,1,-1), 2, false);
                yield return (new Vector3(0,0,0), new Vector3(1,0,-1), 2, false);
                yield return (new Vector3(0,0,0), new Vector3(1,-1,0), 2, false);
                yield return (new Vector3(0,0,0), new Vector3(0,-1,1), 2, false);
                yield return (new Vector3(0,0,0), new Vector3(-1,0,1), 2, false);
                yield return (new Vector3(0,0,0), new Vector3(-1,1,0), 2, false);

                yield return (new Vector3(0,0,0), new Vector3(0,3,-3), 2, false);
                yield return (new Vector3(0,0,0), new Vector3(2,1,-3), 2, false);
                yield return (new Vector3(0,0,0), new Vector3(1,2,-3), 2, false);
                yield return (new Vector3(0,0,0), new Vector3(0,-3,3), 2, false);
                yield return (new Vector3(0,0,0), new Vector3(1,2,-3), 2, false);
                #endregion
            }
        }
        //write the above test for non cube coordinates, because I suspect it won't work. In fact, I suspect all the ring methods don't work for non cube coordinates.
    }
}
