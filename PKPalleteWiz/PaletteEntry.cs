using System;
using System.ComponentModel;
using System.Windows.Media;

namespace PKPaletteWiz
{
    [Serializable]
    public class PaletteEntry : INotifyPropertyChanged
    {
        private Color _color = Colors.AliceBlue;
        

        public Color Color { get => _color; set => ChangeProperty(ref _color, value); }     
        public string HexValue { get => _color.ToString(); }
        
        
        [field: NonSerialized]
        public event PropertyChangedEventHandler PropertyChanged;

        private void ChangeProperty<T>(ref T oldValue, T newValue)
        {
            if (oldValue.Equals(newValue)) return;

            oldValue = newValue;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(null)); // can be set to null, which means all properties have been changed at once
        }
    }
}
