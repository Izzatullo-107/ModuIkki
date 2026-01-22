using Dars2_5_Abstarakshin.Models;
using Dars2_5_Abstarakshin.Services.Interfaces;

namespace Dars2_5_Abstarakshin.Services;

internal class BlackBoardService : IBlackBoard
{
    List<BlackBoard> Boards;

    public BlackBoardService()
    {
        Boards = new List<BlackBoard>();
    }

    //{C}
    public Guid AddBlackBoard(BlackBoard blackBoard)
    {
        blackBoard.BlackBoardId = Guid.NewGuid();
        Boards.Add(blackBoard);
        return blackBoard.BlackBoardId;
    }

    //{R}
    public BlackBoard? GetBlackBoardById(Guid blackBoardId)
    {
        return Boards.FirstOrDefault(c => c.BlackBoardId == blackBoardId);
    }
    public List<BlackBoard> GetAllBlackBoards()
    {
        return Boards;
    }

    //{U}
    public bool UpdateBlackBoard(BlackBoard blackBoard)
    {
        var updateBlackBoard = Boards.FirstOrDefault(c => c.BlackBoardId == blackBoard.BlackBoardId);
        if (updateBlackBoard != null)
        {
            updateBlackBoard.Name = blackBoard.Name;
            updateBlackBoard.Color = blackBoard.Color;
            updateBlackBoard.Width = blackBoard.Width;
            updateBlackBoard.Height = blackBoard.Height;
            updateBlackBoard.Length = blackBoard.Length;
            return true;
        }
        return false;
    }

    //{D}
    public bool DeleteBlackBoard(Guid blackBoardId)
    {
        var blackBoard = Boards.FirstOrDefault(c => c.BlackBoardId == blackBoardId);
        if (blackBoard != null)
        {
            Boards.Remove(blackBoard);
            return true;
        }
        return false;
    }

   

}
