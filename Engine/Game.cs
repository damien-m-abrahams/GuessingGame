using System;
using System.Collections.Generic;
using System.Linq;
using GuessingGame.DataApi;
using GuessingGame.EngineApi;
using GuessingGame.SubjectApi;

namespace GuessingGame.Engine
{
    public class Game
    {
        private readonly IRepository<ISubject> dataSource;

        public IGameStrategy GameStrategy { get; set; }     

        public Game(IRepository<ISubject> dataSource, IGameStrategy gameStrategy)
        {
            if (dataSource == null) throw new ArgumentNullException(nameof(dataSource));
            if (gameStrategy == null) throw new ArgumentNullException(nameof(gameStrategy));

            this.dataSource = dataSource;
            GameStrategy = gameStrategy;

            GameStrategy.AllSubjects = dataSource.GetAll();
        }
    }
}
