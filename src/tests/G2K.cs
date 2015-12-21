using System;
using System.Threading.Tasks;
using System.Collections.Generic;

using Gana2Kanji;
using NUnit.Framework;

namespace tests
{
    [TestFixture]
    public class G2KTest
    {
        /* 기본적인 값을 넣어서, 동작 여부만 테스트한다. */
        /* 정확한 테스트를 위해서는 HttpMock 사용 */

        [Test]
        public async Task Convert()
        {
            var candidates = (await G2K.Convert("あける"))[0].candidates;

            Assert.IsTrue(
                candidates.Contains("開ける"));
            Assert.IsTrue(
                candidates.Contains("空ける"));
            Assert.IsTrue(
                candidates.Contains("明ける"));
        }

        [Test]
        public async Task CommonCase()
        {
            Assert.AreEqual(
                (await G2K.Convert("ここではきものをぬぐ")).CommonCase(),
                "ここでは着物を脱ぐ");
        }
    }
}
