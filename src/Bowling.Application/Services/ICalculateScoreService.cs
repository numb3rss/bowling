using System.Collections.Generic;
using Bowling.Domain.ValueObjects;

namespace Bowling.Application.Services
{
    public interface ICalculateScoreService
    {
        int Get(List<Frame> frames);
    }
}
