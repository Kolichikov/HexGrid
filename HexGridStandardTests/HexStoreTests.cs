using HexGridStandard;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace HexGridStandardTests
{
    public class HexStoreTests
    {
        [Test]
        public void CanUpdateValuesOnTilesInHexStoreAfterCallingAll()
        {
            var hexStore = new HexStore<Vector3, TestTile>();

            hexStore.Add(new Vector3(0,0,0), (x)=> throw new Exception(), (x)=>new TestTile());
            hexStore.Add(new Vector3(0,1,0), (x)=> throw new Exception(), (x)=>new TestTile());
            hexStore.Add(new Vector3(0,1,1), (x)=> throw new Exception(), (x)=>new TestTile());
            hexStore.Add(new Vector3(1,1,1), (x)=> throw new Exception(), (x)=>new TestTile());

            for(var i = 0; i < hexStore.Count;i++)
                hexStore[i].ValueA = i+1;
            
            Assert.AreEqual(1, hexStore[0].ValueA);
            Assert.AreEqual(2, hexStore[1].ValueA);
            Assert.AreEqual(3, hexStore[2].ValueA);
            Assert.AreEqual(4, hexStore[3].ValueA);

        }
    }

    public class TestTile
    {
        public int ValueA {get;set;}
    }
}
