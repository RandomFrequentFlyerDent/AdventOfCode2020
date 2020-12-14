using System;
using System.Collections.Generic;

namespace AoC2020Tests
{
    public class TestInput
    {
        public List<string> this[int key]
        {
            get
            {
                if (_input.TryGetValue(key, out List<string> input))
                    return input;
                throw new NotImplementedException($"input {key}");
            }
        }

        private readonly Dictionary<int, List<string>> _input = new Dictionary<int, List<string>>
        {
            { 26, new List<string> {"mask = XXXXXXXXXXXXXXXXXXXXXXXXXXXXX1XXXX0X", "mem[8] = 11", "mem[7] = 101", "mem[8] = 0"} },
            { 25, new List<string> {"939", "1789,37,47,1889" } },
            { 24, new List<string> {"939", "67,7,x,59,61" } },
            { 23, new List<string> {"939", "67,x,7,59,61" } },
            { 22, new List<string> {"939", "67,7,59,61" } },
            { 21, new List<string> {"939", "17,x,13,19" } },
            { 20, new List<string> {"939", "7,13,x,x,59,x,31,19" } },
            { 19, new List<string> { "F10", "N3", "F7", "R90", "F11" } },
            { 18, new List<string>
            {
                "L.LL.LL.LL",
                "LLLLLLL.LL",
                "L.L.L..L..",
                "LLLL.LL.LL",
                "L.LL.LL.LL",
                "L.LLLLL.LL",
                "..L.L.....",
                "LLLLLLLLLL",
                "L.LLLLLL.L",
                "L.LLLLL.LL"
            } },
            { 17, new List<string> {"28","33","18","42","31","14","46","20","48","47","24","23", "49","45","19","38","39","11","1","32","25","35","8","17","7","9","4","2","34","10","3"} },
            { 16, new List<string> { "16", "10", "15", "5", "1", "11", "7", "19", "6", "12", "4" } },
            { 15, new List<string> { "35","20","15","25","47","40","62","55","65","95","102","117","150","182","127","219","299","277","309","576"} },
            { 14, new List<string> { "nop +0", "acc +1", "jmp +4", "acc +3", "jmp -3", "acc -99", "acc +1", "jmp -4", "acc +6" } },
            { 13, new List<string>
            {
                "shiny gold bags contain 2 dark red bags.",
                "dark red bags contain 2 dark orange bags.",
                "dark orange bags contain 2 dark yellow bags.",
                "dark yellow bags contain 2 dark green bags.",
                "dark green bags contain 2 dark blue bags.",
                "dark blue bags contain 2 dark violet bags.",
                "dark violet bags contain no other bags."
            } },
            { 12, new List<string>
            {
                "light red bags contain 1 bright white bag, 2 muted yellow bags.",
                "dark orange bags contain 3 bright white bags, 4 muted yellow bags.",
                "bright white bags contain 1 shiny gold bag.",
                "muted yellow bags contain 2 shiny gold bags, 9 faded blue bags.",
                "shiny gold bags contain 1 dark olive bag, 2 vibrant plum bags.",
                "dark olive bags contain 3 faded blue bags, 4 dotted black bags.",
                "vibrant plum bags contain 5 faded blue bags, 6 dotted black bags.",
                "faded blue bags contain no other bags.",
                "dotted black bags contain no other bags."
            } },
            { 11, new List<string> { "abc", "", "a", "b", "c", "", "ab", "ac", "", "a", "a", "a", "a", "", "b" } },
            { 10, new List<string> { "FBFBBFFRLR" } },
            { 9, new List<string> { "BFFFBBFRRR" } },
            { 8, new List<string> { "FFFBBBFRRR" } },
            { 7, new List<string> { "BBFFBBFRLL" } },
            { 6, new List<string>
            {
                "eyr:1972 cid:100",
                "hcl:#18171d ecl:amb hgt:170 pid:186cm iyr:2018 byr:1926",
                "",
                "iyr:2019",
                "hcl:#602927 eyr:1967 hgt:170cm",
                "ecl:grn pid:012533040 byr:1946",
                "",
                "hcl:dab227 iyr:2012",
                "ecl:brn hgt:182cm pid:021572410 eyr:2020 byr:1992 cid:277",
                "",
                "hgt:59cm ecl:zzz",
                "eyr:2038 hcl:74454a iyr:2023",
                "pid:3556412378 byr:2007"
            } },
            { 5, new List<string>
            {
                "pid:087499704 hgt:74in ecl:grn iyr:2012 eyr:2030 byr:1980",
                "hcl:#623a2f",
                "",
                "eyr:2029 ecl:blu cid:129 byr:1989",
                "iyr:2014 pid:896056539 hcl:#a97842 hgt:165cm",
                "",
                "hcl:#888785",
                "hgt:164cm byr:2001 iyr:2015 cid:88",
                "pid:545766238 ecl:hzl",
                "eyr:2022",
                "iyr:2010 hgt:158cm hcl:#b6652a ecl:blu byr:1944 eyr:2021 pid:093154719"
            } },
            { 4, new List<string>
            {
                "ecl:gry pid:860033327 eyr:2020 hcl:#fffffd",
                "byr:1937 iyr:2017 cid:147 hgt:183cm",
                "",
                "iyr:2013 ecl:amb cid:350 eyr:2023 pid:028048884",
                "hcl:#cfa07d byr:1929",
                "",
                "hcl:#ae17e1 iyr:2013",
                "eyr:2024",
                "ecl:brn pid:760753108 byr:1931",
                "hgt:179cm",
                "",
                "hcl:#cfa07d eyr:2025 pid:166559648",
                "iyr:2011 ecl:brn hgt:59in"
            } },
            { 3, new List<string>
            {
                "..##.......",
                "#...#...#..",
                ".#....#..#.",
                "..#.#...#.#",
                ".#...##..#.",
                "..#.##.....",
                ".#.#.#....#",
                ".#........#",
                "#.##...#...",
                "#...##....#",
                ".#..#...#.#"
            } },
            { 2, new List<string> { "1-3 a: abcde", "1-3 b: cdefg", "2-9 c: ccccccccc" } },
            { 1, new List<string> { "1721", "979", "366", "299", "675", "1456" } },
        };
    }
}
