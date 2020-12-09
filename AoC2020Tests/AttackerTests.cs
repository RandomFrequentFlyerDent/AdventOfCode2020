using AdventOfCode2020.dataport;
using NUnit.Framework;
using System.Collections.Generic;

namespace AoC2020Tests
{
    public class AttackerTests
    {
        private Attacker _attacker;
        private readonly List<string> _input = new List<string>
        { "35","20","15","25","47","40","62","55","65","95","102","117","150","182","127","219","299","277","309","576"};

        [SetUp]
        public void SetUp()
        {
            _attacker = new Attacker();
        }

        [TestCase(XMAS.TestPreamble, 127)]
        [TestCase(XMAS.TestEncryptionWeakness, 62)]
        public void ShouldAttack(XMAS xMAS, int expected)
        {
            var actual = _attacker.GetAnswer(_input, xMAS);
            Assert.AreEqual(expected, actual);
        }
    }
}
