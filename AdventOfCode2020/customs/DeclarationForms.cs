using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2020.customs
{
    public class DeclarationForms : BaseLogic<CustomsType>
    {
        public override object GetAnswer(List<string> input, CustomsType customsType)
        {
            var answer = customsType == CustomsType.AnyoneYes
                ? GetAnswersByGroupByPerson(input)
                    .ToDictionary(d => d.Key, d => d.Value.SelectMany(id => id.Value).ToList().Distinct())
                    .Sum(d => d.Value.Count())
                : GetPeopleByAnswerByGroup(input)
                    .Sum(d => d.Value.Count());

            return answer;
        }

        private Dictionary<int, Dictionary<int, IEnumerable<char>>> GetAnswersByGroupByPerson(List<string> input)
        {
            Dictionary<int, Dictionary<int, IEnumerable<char>>> answersByGroupByPerson = new Dictionary<int, Dictionary<int, IEnumerable<char>>>();
            Dictionary<int, IEnumerable<char>> answersByPerson = new Dictionary<int, IEnumerable<char>>();
            List<char> yesAnswers = new List<char>();
            int group = 0;
            int person = 0;

            for (int i = group; i < input.Count; i++)
            {
                var answers = input[i];
                if (i != 0 && string.IsNullOrEmpty(answers))
                {
                    answersByGroupByPerson.Add(group, answersByPerson);
                    yesAnswers = new List<char>();
                    answersByPerson = new Dictionary<int, IEnumerable<char>>();
                    group++;
                    person = 0;
                    continue;
                }

                yesAnswers.AddRange(answers);
                answersByPerson.Add(person, yesAnswers);
                yesAnswers = new List<char>();
                person++;

                if (i + 1 == input.Count)
                {
                    answersByGroupByPerson.Add(group, answersByPerson);
                    continue;
                }
            }

            return answersByGroupByPerson;
        }

        private Dictionary<int, Dictionary<char, List<int>>> GetPeopleByAnswerByGroup(List<string> input)
        {
            var peopleByAnswerByGroup = new Dictionary<int, Dictionary<char, List<int>>>();
            var answersByGroupByPerson = GetAnswersByGroupByPerson(input);
            foreach (var answerByGroupByPerson in answersByGroupByPerson)
            {
                var personByAnswer = new Dictionary<char, List<int>>();
                foreach (var answerByPerson in answerByGroupByPerson.Value)
                {
                    answerByPerson.Value.ToList().ForEach(c =>
                    {
                        if (personByAnswer.ContainsKey(c))
                        {
                            personByAnswer[c].Add(answerByPerson.Key);
                        }
                        else
                        {
                            personByAnswer.Add(c, new List<int> { answerByPerson.Key });
                        }
                    });
                }
                peopleByAnswerByGroup.Add(answerByGroupByPerson.Key, 
                    personByAnswer.Where(pba => pba.Value.Count() == answerByGroupByPerson.Value.Keys.Count())
                    .ToDictionary(pba => pba.Key, pba => pba.Value));
            }

            return peopleByAnswerByGroup;
        }
    }
}
