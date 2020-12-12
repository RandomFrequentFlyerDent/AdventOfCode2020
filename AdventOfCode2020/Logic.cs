using AdventOfCode2020.charger;
using AdventOfCode2020.customs;
using AdventOfCode2020.dataport;
using AdventOfCode2020.entertainment;
using AdventOfCode2020.expenses;
using AdventOfCode2020.luggage;
using AdventOfCode2020.navigation;
using AdventOfCode2020.passport;
using AdventOfCode2020.password;
using AdventOfCode2020.seating.ferry;
using AdventOfCode2020.seating.plane;
using AdventOfCode2020.trajectory;
using System;
using System.Collections.Generic;

namespace AdventOfCode2020
{
    public interface ILogic
    {
        object GetAnswer(List<string> input, int modifier);
    }

    public class Logic
    {
        private readonly Dictionary<int, ILogic> _logic = new Dictionary<int, ILogic>
        {
            { 1, new ExpenseReport() },
            { 2, new DatabaseChecker() },
            { 3, new RoutePlanner() },
            { 4, new IdentityDocumentScanner() },
            { 5, new BoardingPassScanner() },
            { 6, new DeclarationForms() },
            { 7, new LuggageValidator() },
            { 8, new GameConsoleDebugger() },
            { 9, new Attacker() },
            { 10, new DeviceCharger() },
            { 11, new LayoutManager() },
            { 12, new FerrySteering() }
        };

        public ILogic this[int key]
        {
            get
            {
                if (_logic.TryGetValue(key, out ILogic logic))
                    return logic;
                throw new NotImplementedException($"Day {key}");
            }
        }
    }
}
