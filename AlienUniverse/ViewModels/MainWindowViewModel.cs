using System.Collections.ObjectModel;
using System.Reactive;
using System.Linq;
using AlienUniverse.Models;
using ReactiveUI;
using AlienUniverse.Views;

namespace AlienUniverse.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        public ReactiveCommand<Unit, Unit> AddNewMovieCommand { get; }
        public ReactiveCommand<Unit, Unit> RemoveMovieCommand { get; }
        public ReactiveCommand<Unit, Unit> ShowCharactersCommand { get; }

        public ObservableCollection<MovieModel> Movies { get; set; } = new()
        {
             new MovieModel()
        {
            Title = "Alien",
            TitleP = "Obcy – ósmy pasażer Nostromo",
            ReleaseDate = "1979",
            Director = "Ridley Scott",
            Script = "Dan O’Bannon",
            Genre = "Sci-Fi / Horror",
            TimeLength = "117 minut",
            Rating = 8.5,
            MainCharacters = "Ellen Ripley, Dallas, Ash, Lambert, Kane",
            Ship = "USCSS Nostromo",
            Description =
                "Załoga statku handlowego Nostromo odbiera sygnał z nieznanej planety. Po lądowaniu odkrywają obcą formę życia, która zaczyna eliminować członków załogi jeden po drugim.",
            FunFacts =
                "Scena z „wyskakującym potworem” z klatki piersiowej aktora była niespodzianką dla obsady – ich reakcje są autentyczne."
        },

        new MovieModel()
        {
            Title = "Aliens",
            TitleP = "Obcy – decydujące starcie",
            ReleaseDate = "1986",
            Director = "James Cameron",
            Script = "James Cameron, David Giler, Walter Hill",
            Genre = "Sci-Fi / Akcja / Horror",
            TimeLength = "137 minut",
            Rating = 8.4,
            MainCharacters = "Ellen Ripley, Hicks, Newt, Bishop, Vasquez",
            Ship = "USS Sulaco",
            Description =
                "Ripley, jedyna ocalała z wcześniejszego ataku obcego, wraca z oddziałem kolonialnych marines na księżyc LV-426, by zbadać utratę kontaktu z kolonią. Wkrótce stają oko w oko z armią obcych.",
            FunFacts =
                "James Cameron napisał scenariusz podczas lotu do Londynu, tworząc tytuł, który jest liczbą mnogą słowa „Alien” – symbolicznie zapowiadając, że tym razem potworów będzie więcej."
        },

        new MovieModel()
        {
            Title = "Alien³",
            TitleP = "Obcy³",
            ReleaseDate = "1992",
            Director = "David Fincher",
            Script = "David Giler, Walter Hill, Larry Ferguson",
            Genre = "Sci-Fi / Horror",
            TimeLength = "114 minut",
            Rating = 6.5,
            MainCharacters = "Ellen Ripley, Dillon, Clemens, Morse, Andrews",
            Ship = "E.E.V. z USS Sulaco (katastrofa)",
            Description =
                "Po katastrofie statku Sulaco Ripley trafia na więzienną planetę Fiorina 161, gdzie wkrótce pojawia się obcy. Pozbawiona broni i wsparcia, musi walczyć o życie wśród skazańców i odkrywa, że nosi w sobie embrion królowej obcych.",
            FunFacts =
                "David Fincher zadebiutował tym filmem jako reżyser, jednak miał ograniczoną kontrolę twórczą, a produkcja była pełna konfliktów – reżyser później odciął się od tego projektu."
        },

        new MovieModel()
        {
            Title = "Alien: Resurrection",
            TitleP = "Obcy: Przebudzenie",
            ReleaseDate = "1997",
            Director = "Jean-Pierre Jeunet",
            Script = "Joss Whedon",
            Genre = "Sci-Fi / Horror",
            TimeLength = "109 minut",
            Rating = 6.2,
            MainCharacters = "Ellen Ripley (klon), Call, Johner, Christie, Dr. Gediman",
            Ship = "USM Auriga",
            Description =
                "Dwieście lat po śmierci Ripley naukowcy klonują ją, by wydobyć królową obcych z jej ciała. Klonowana Ripley zyskuje niezwykłe zdolności i wraz z grupą kosmicznych najemników musi zapobiec katastrofie, gdy obcy wydostają się na wolność.",
            FunFacts =
                "Postać androidki Call gra Winona Ryder, a film miał początkowo być początkiem nowej trylogii, która jednak nigdy nie powstała."
        },

        new MovieModel()
        {
            Title = "Prometheus",
            TitleP = "Prometeusz",
            ReleaseDate = "2012",
            Director = "Ridley Scott",
            Script = "Jon Spaihts, Damon Lindelof",
            Genre = "Sci-Fi / Thriller",
            TimeLength = "124 minuty",
            Rating = 7.0,
            MainCharacters = "Elizabeth Shaw, David, Charlie Holloway, Meredith Vickers",
            Ship = "USCSS Prometheus",
            Description =
                "Ekspedycja naukowa wyrusza na odległą planetę, by odkryć pochodzenie ludzkości. Na miejscu załoga Prometeusza odkrywa ruiny cywilizacji Inżynierów oraz coś, co nigdy nie powinno zostać obudzone.",
            FunFacts =
                "Ridley Scott planował, aby film stanowił zarówno prequel „Obcego”, jak i samodzielną opowieść o powstaniu życia i człowieka – wiele elementów łączy się z mitologią obcych w sposób pośredni."
        },

        new MovieModel()
        {
            Title = "Alien: Covenant",
            TitleP = "Obcy: Przymierze",
            ReleaseDate = "2017",
            Director = "Ridley Scott",
            Script = "John Logan, Dante Harper",
            Genre = "Sci-Fi / Horror",
            TimeLength = "122 minuty",
            Rating = 6.4,
            MainCharacters = "Daniels, David, Walter, Oram, Tennessee",
            Ship = "USCSS Covenant",
            Description =
                "Załoga statku kolonizacyjnego Covenant odkrywa nieznaną planetę, idealną do osiedlenia. Na miejscu natrafiają jednak na Davida – syntetyka ocalałego z Prometeusza – oraz nowe formy obcych stworzeń, które mogą zakończyć ludzką ekspansję w kosmosie.",
            FunFacts =
                "Film pierwotnie miał być zatytułowany „Paradise Lost”, a reżyser planował jeszcze jedną część łączącą fabułę z oryginalnym „Obcym” z 1979 roku."
        }
        };

        private MovieModel _selectedMovie;
        public MovieModel SelectedMovie
        {
            get => _selectedMovie;
            set => this.RaiseAndSetIfChanged(ref _selectedMovie, value);
        }

        private MovieModel _newMovie = new MovieModel();
        public MovieModel NewMovie
        {
            get => _newMovie;
            set => this.RaiseAndSetIfChanged(ref _newMovie, value);
        }

        public MainWindowViewModel()
        {
            RemoveMovieCommand = ReactiveCommand.Create(RemoveMovie);

            AddNewMovieCommand = ReactiveCommand.Create(() =>
            {
                Movies.Add(NewMovie);
                SelectedMovie = NewMovie;
                NewMovie = new MovieModel();
            });

            ShowCharactersCommand = ReactiveCommand.Create(ShowCharacters);
        }

        private void RemoveMovie()
        {
            if (SelectedMovie != null)
            {
                Movies.Remove(SelectedMovie);
                SelectedMovie = null;
            }
        }

        private void ShowCharacters()
        {
            if (SelectedMovie != null && !string.IsNullOrEmpty(SelectedMovie.MainCharacters))
            {
                var characters = SelectedMovie.MainCharacters.Split(',')
                    .Select(c => c.Trim())
                    .ToList();

                var window = new CharactersWindow
                {
                    DataContext = new CharactersViewModel(characters)
                };
                window.Show();
            }
        }
    }
}
