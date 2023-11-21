int AlphaBeta(Board board, int depth, int alpha, int beta, bool isMaximizingPlayer)
{
    if (depth == 0)
    {
        return EvaluateBoard(board); // Assuming you have an evaluation function
    }

    if (isMaximizingPlayer)
    {
        int maxEval = int.MinValue;
        foreach (var move in board.GetLegalMoves())
        {
            Board newBoard = board.Clone();
            newBoard.MakeMove(move);
            int eval = AlphaBeta(newBoard, depth - 1, alpha, beta, false);
            maxEval = Math.Max(maxEval, eval);
            alpha = Math.Max(alpha, eval);
            if (beta <= alpha)
                break; // Beta cut-off
        }
        return maxEval;
    }
    else
    {
        int minEval = int.MaxValue;
        foreach (var move in board.GetLegalMoves())
        {
            Board newBoard = board.Clone();
            newBoard.MakeMove(move);
            int eval = AlphaBeta(newBoard, depth - 1, alpha, beta, true);
            minEval = Math.Min(minEval, eval);
            beta = Math.Min(beta, eval);
            if (beta <= alpha)
                break; // Alpha cut-off
        }
        return minEval;
    }
}
