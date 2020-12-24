using AdventOfCode2020.bus;
using AdventOfCode2020.charger;
using AdventOfCode2020.customs;
using AdventOfCode2020.dataport;
using AdventOfCode2020.entertainment;
using AdventOfCode2020.expenses;
using AdventOfCode2020.game;
using AdventOfCode2020.homework;
using AdventOfCode2020.lobby;
using AdventOfCode2020.luggage;
using AdventOfCode2020.navigation;
using AdventOfCode2020.passport;
using AdventOfCode2020.password;
using AdventOfCode2020.seating.ferry;
using AdventOfCode2020.seating.plane;
using AdventOfCode2020.train;
using AdventOfCode2020.trajectory;
using System;
using System.Collections.Generic;

namespace AdventOfCode2020
{
    public interface ILogic
    {
        object GetAnswer(List<string> input, int part);
    }

    public class Logic
    {
        private readonly Dictionary<int, ILogic> _logic = new Dictionary<int, ILogic>
        {
            { 24, new TileFlipper() },
            { 18, new MathHomework() },
            { 16, new TicketValidator() },
            { 15, new MemoryGame() },
            { 14, new Initializer() },
            { 13, new BusScheduler() },
            { 12, new FerrySteering() },
            { 11, new LayoutManager() },
            { 10, new DeviceCharger() },
            { 9, new Attacker() },
            { 8, new GameConsoleDebugger() },
            { 7, new LuggageValidator() },
            { 6, new DeclarationForms() },
            { 5, new BoardingPassScanner() },
            { 4, new IdentityDocumentScanner() },
            { 3, new RoutePlanner() },
            { 2, new DatabaseChecker() },
            { 1, new ExpenseReport() },
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
