using System.Collections.Generic;
using ReactiveUI;

namespace AlienUniverse.ViewModels
{
    public class CharactersViewModel : ViewModelBase
    {
        public List<string> Characters { get; }

        public CharactersViewModel(List<string> characters)
        {
            Characters = characters;
        }
    }
}