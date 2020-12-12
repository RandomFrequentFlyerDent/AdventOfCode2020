using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2020.customs
{
    public class DeclarationForms : ILogic
    {
        public object GetAnswer(List<string> input, int part)
        {
            var answer = part == 1
                ? GetSumOfDistinctYesAnswers(input)
                : GetSumOfCommonYesAnswers(input);
            return answer;
        }

        private int GetSumOfDistinctYesAnswers(List<string> input)
        {
            var distinctAnswersByGroupByPerson = GetAnswersByGroupByPerson(input)
                .ToDictionary(d => d.Key, d => d.Value.SelectMany(id => id.Value).ToList().Distinct());
            return distinctAnswersByGroupByPerson.Sum(d => d.Value.Count());
        }

        private int GetSumOfCommonYesAnswers(List<string> input)
        {
            var peopleByAnswerByGroup = GetPeopleByAnswerByGroup(input);
            return peopleByAnswerByGroup.Sum(d => d.Value.Count());
        }

        private Dictionary<int, Dictionary<int, List<char>>> GetAnswersByGroupByPerson(List<string> input)
        {
            var seperatedInput = InputReader.ConvertToSeperatedInput(input);
            Dictionary<int, Dictionary<int, List<char>>> answersByGroupByPerson = new Dictionary<int, Dictionary<int, List<char>>>();
            int group = 0;
            int person = 0;

            for (int i = group; i < seperatedInput.Count; i++)
            {
                var answersByGroup = seperatedInput[i];
                var answersByPerson = new Dictionary<int, List<char>>();
                for (int j = person; j < answersByGroup.Count; j++)
                {
                    var answers = answersByGroup[j].ToList();
                    answersByPerson.Add(j, answers);
                }
                answersByGroupByPerson.Add(i, answersByPerson);
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
