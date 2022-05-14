using System.Collections.Generic;
using System.Linq;
using JapaneseFerry.Enums;
using JapaneseFerry.Panels;

namespace JapaneseFerry;

public static class GameRulesChecker
{
    private static Dictionary<string, BasePanel> _panels;
    private static List<BasePanel> _leftSidePanels;
    private static List<BasePanel> _rightSidePanels;
    private static List<BasePanel> _onBoat;
    private static PositionState _boatPositionState;

    public static BoatPanel Boat { get; set; } = new();
    public static Dictionary<string, BasePanel> AllPanels { get; set; } = new()
    {
        ["Mother"] = new MotherPanel(),
        ["DaughterOne"] = new DaughterOnePanel(),
        ["DaughterTwo"] = new DaughterTwoPanel(),
        ["Father"] = new FatherPanel(),
        ["SonOne"] = new SonOnePanel(),
        ["SonTwo"] = new SonTwoPanel(),
        ["Criminal"] = new CriminalPanel(),
        ["Police"] = new PolicePanel()
    };

    public static bool Check(Dictionary<string, BasePanel> panels, PositionState boatPositionState, out string message)
    {
        message = string.Empty;
        _panels = panels;
        _boatPositionState = boatPositionState;
        _onBoat = _panels.Values
            .Where(item => item.IsOnBoat)
            .ToList();

        #region Проверка всего, что связано с нахождением на лодке
        
        // Проверка на то, что дети одни на лодке
        if (ChildrenAloneOnBoat())
        {
            message = "Дети не могут передвигаться одни на лодке";
            return false;
        }
        
        // Проверка на то, что преступник передвигается в сопровождении полиции
        if (CriminalOnBoat())
        {
            if (CriminalWithoutPoliceOnBoat())
            {
                message = "Преступник может передвигаться только в сопровождении полиции.";
                return false;
            }
        }
        
        // Проверка на то, что на лодке не находятся 2 родителя одновременно
        if (!TwoParentsOnBoat())
        {
            // Проверка на то, что ребенок с корректным родителем на лодке.
            if (!ChildWithCorrectParentOnBoat())
            {
                message = "Некорректное сопоставление родителя и ребенка на лодке.";
                return false;
            }
        }
        
        #endregion
        
        _leftSidePanels = _panels.Values
            .Where(item => !item.IsOnBoat && item.PositionState == PositionState.LeftSide)
            .ToList();
        _rightSidePanels = _panels.Values
            .Where(item => !item.IsOnBoat && item.PositionState == PositionState.RightSide)
            .ToList();

        #region Проверка островов

        // Проверка на то, что преступник не может быть без полиции, но если он один на острове, то может
        if (!CriminalOnBoat())
        {
            for (var i = 0; i < 2; i++)
            {
                if (i == 1)
                {
                    _leftSidePanels = AddBoatToPanels(_leftSidePanels);
                    _rightSidePanels = AddBoatToPanels(_rightSidePanels);
                }
                
                if (CriminalWithoutPolice(_leftSidePanels) && !IsCriminalAlone(_leftSidePanels) ||
                    CriminalWithoutPolice(_rightSidePanels) && !IsCriminalAlone(_rightSidePanels))
                {
                    message = "Преступник не может остаться без сопровождения полиции";
                    return false;
                }
            }

            _leftSidePanels = RemoveBoatFromPanels(_leftSidePanels);
            _rightSidePanels = RemoveBoatFromPanels(_rightSidePanels);
        }
        
        // Проверка островов на корректное сопоставление родителей
        if (!TwoParentsOnBoat() && !CriminalOnBoat() && !PoliceOnBoat())
        {
            if (!ParentOnBoat()) return true;
            
            for (var i = 0; i < 2; i++)
            {
                if (i == 1)
                {
                    switch (_boatPositionState)
                    {
                        case PositionState.LeftSide:
                            _rightSidePanels = AddBoatToPanels(_rightSidePanels);
                            break;
                        case PositionState.RightSide:
                            _leftSidePanels = AddBoatToPanels(_leftSidePanels);
                            break;
                    }
                }

                if (ChildWithCorrectCharacter(_leftSidePanels) &&
                    ChildWithCorrectCharacter(_rightSidePanels)) continue;
                    
                message = "Некорректное сопоставление детей на острове.";
                return false;
            }
                
            _leftSidePanels = RemoveBoatFromPanels(_leftSidePanels);
            _rightSidePanels = RemoveBoatFromPanels(_rightSidePanels);
        }

        #endregion
        
        return true;
    }

    private static List<BasePanel> AddBoatToPanels(List<BasePanel> panels)
    {
        panels.AddRange(_onBoat);
        return panels;
    }

    private static List<BasePanel> RemoveBoatFromPanels(List<BasePanel> panels)
    {
        foreach (var item in _onBoat)
            panels.Remove(item);

        return panels;
    }

    private static int ChildrenCount(List<BasePanel> panels)
    {
        var childrenList = new [] {"DaughterOne", "DaughterTwo", "SonOne", "SonTwo"};

        return panels.Count(item => childrenList.Contains(item.Name));
    }

    private static bool ChildrenAlone(List<BasePanel> panels) =>
        ChildrenCount(panels) == panels.Count;

    private static bool ChildrenAloneOnBoat()
    {
        var childrenList = new [] {"DaughterOne", "DaughterTwo", "SonOne", "SonTwo"};

        if (_onBoat.Count == 1 && childrenList.Contains(_onBoat[0].Name)) return true;
        return _onBoat.Count(item => childrenList.Contains(item.Name)) == 2;
    }
    
    private static bool CriminalOnBoat() =>
        _onBoat.Any(item => item.Name == "Criminal");

    private static bool PoliceOnBoat() =>
        _onBoat.Any(item => item.Name == "Police");

    private static bool CriminalWithoutPolice(List<BasePanel> panels)
    {
        var isListContainsCriminal = panels.Any(item => item.Name == "Criminal");
        return isListContainsCriminal && panels.All(item => item.Name != "Police");
    }

    private static bool CriminalWithoutPoliceOnBoat() =>
        CriminalWithoutPolice(_onBoat);

    private static bool TwoParentsTogether(List<BasePanel> panels)
    {
        var parentsList = new[] {"Father", "Mother"};
        return panels.Count(item => parentsList.Contains(item.Name)) == 2;
    }

    private static bool TwoParentsOnBoat() =>
        TwoParentsTogether(_onBoat);

    private static bool ParentOnBoat() =>
        _onBoat.Any(item => item.Name is "Father" or "Mother");

    private static bool ChildWithCorrectCharacter(List<BasePanel> panels)
    {
        var childName = new List<string>();
        var parentName = new List<string>();

        foreach (var item in panels)
        {
            switch (item.Name)
            {
                case "SonOne" or "SonTwo" or "DaughterOne" or "DaughterTwo":
                    childName.Add(item.Name);
                    break;
                case "Father" or "Mother":
                    parentName.Add(item.Name);
                    break;
            }
        }

        if ((childName.Contains("SonOne") || childName.Contains("SonTwo")) &&
            !parentName.Contains("Father") && !ChildrenAlone(panels)) 
            return panels.All(item => item.Name != "Mother");
        
        if ((childName.Contains("DaughterOne") || childName.Contains("DaughterTwo")) &&
            !parentName.Contains("Mother") && !ChildrenAlone(panels))
            return panels.All(item => item.Name != "Father");
        
        return true;
    }

    private static bool ChildWithCorrectParentOnBoat()
    {
        var impossibleOptionsWithFather = new[] {"DaughterOne", "DaughterTwo"};
        var impossibleOptionsWithMother = new[] {"SonOne", "SonTwo"};

        var parentOnBoat = false;
        var parentName = string.Empty;
        
        foreach (var item in _onBoat.Where(item => item.Name is "Father" or "Mother"))
        {
            parentOnBoat = true;
            parentName = item.Name;
            break;
        }

        if (!parentOnBoat) return true;

        foreach (var item in _onBoat)
        {
            if (parentName == "Father")
            {
                if (impossibleOptionsWithFather.Contains(item.Name)) return false;
            }
            else
            {
                if (impossibleOptionsWithMother.Contains(item.Name)) return false;
            }
        }

        return true;
    }

    private static bool IsCriminalAlone(List<BasePanel> panels) =>
        panels.Count == 1 && panels[0].Name == "Criminal";
}