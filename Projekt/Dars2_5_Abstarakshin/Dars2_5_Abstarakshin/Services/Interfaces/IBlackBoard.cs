using Dars2_5_Abstarakshin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dars2_5_Abstarakshin.Services.Interfaces;

internal interface IBlackBoard
{
    public Guid AddBlackBoard(BlackBoard blackBoard);
    public bool UpdateBlackBoard(BlackBoard blackBoard);
    public bool DeleteBlackBoard(Guid blackBoardId);
    public BlackBoard? GetBlackBoardById(Guid blackBoardId);
    public List<BlackBoard> GetAllBlackBoards();
}
