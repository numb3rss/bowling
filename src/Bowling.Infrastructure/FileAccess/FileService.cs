using System;
using Bowling.Application.Services;
using Bowling.Infrastructure.Factories;
using Bowling.Infrastructure.Wrappers;

namespace Bowling.Infrastructure.FileAccess
{
    internal class FileService : IFileService
    {
        private const string PathFile = @"C:\score_bowler.txt";
        private readonly IFactory<string, IStreamWriter> _streamWriterFactory;

        public FileService(IFactory<string, IStreamWriter> streamWriterFactory)
        {
            _streamWriterFactory = streamWriterFactory;
        }

        public void Write(int score)
        {
            try
            {
                using (var streamWriter = _streamWriterFactory.Get(PathFile))
                {
                    streamWriter.WriteLine($"bowler mark {score} points.");
                }
            }
            catch (Exception exception)
            {
                throw new InfrastructureException(exception.Message);
            }
        }
    }
}
