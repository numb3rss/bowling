using System.Linq;
using Bowling.Application.Services;
using Bowling.Domain.Entities;

namespace Bowling.Application.UseCases
{
    public class GetBowlerScoreUseCase : IRequestHandler<string, Score>
    {
        private readonly ICalculateScoreService _calculateScoreService;

        public GetBowlerScoreUseCase(ICalculateScoreService calculateScoreService)
        {
            _calculateScoreService = calculateScoreService;
        }

        public Score Handle(string data)
        {
            var bowler = new Bowler(data);

            var calculationValue = _calculateScoreService.Get(bowler.Frames.ToList());

            return new Score(calculationValue);
        }
    }
}
