using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using Affine_Transformer;
using System.Drawing;

namespace Testing
{
    [TestFixture]
    public class testImageProcess
    {
        ImageProcessor obj;
        [SetUp]
        public void Setup()
        {
            obj = new ImageProcessor();
            
        }
        /// <summary>
        /// array test
        /// </summary>
        //[Test]
        //public void ParallelogramaffineDataTest()
        //{
        //    var processBuffer = new byte[4096 *4096];
        //    int maxLineLength = 4096;
        //    int blockLength = 128;
        //    int mainLine =0;
            
        //    int bitmapMaxBlockNum = maxLineLength/blockLength;

        //    byte[] ret = obj.ParallelogramChanger(processBuffer, maxLineLength,  blockLength, bitmapMaxBlockNum, mainLine);
        //    Assert.That(ret, Is.EqualTo(processBuffer));
        //}
    }
}
