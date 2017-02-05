using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace PruebasConXamarin.Views.XAML.TapGestures
{
    public partial class MonkeyTapPage : ContentPage
    {
        private const int SequenceTime = 750; // in msec 
        protected const int FlashDuration = 250;
        private const double OffLuminosity = 0.4; // somewhat dimmer 
        private const double OnLuminosity = 0.75; // much brighter 
        BoxView[] boxViews;
        Color[] colors = {Color.Red, Color.Blue, Color.Yellow, Color.Green};
        List<int> sequence = new List<int>();
        private int _sequenceIndex;
        private bool _awaitingTaps;
        private bool _gameEnded;

        Random random = new Random();

        public MonkeyTapPage()
        {
            InitializeComponent();
            boxViews = new BoxView[] {boxview0, boxview1, boxview2, boxview3};
            InitializeBoxViewColors();
        }

        void InitializeBoxViewColors()
        {
            for (int index = 0; index < 4; index++)
                boxViews[index].Color = colors[index].WithLuminosity(OffLuminosity);
        }

        protected void OnStartGameButtonClicked(object sender, EventArgs args)
        {
            _gameEnded = false;
            startGameButton.IsVisible = false;
            InitializeBoxViewColors();
            sequence.Clear();
            StartSequence();
        }

        void StartSequence()
        {
            sequence.Add(random.Next(4));
            _sequenceIndex = 0;
            Device.StartTimer(TimeSpan.FromMilliseconds(SequenceTime), OnTimerTick);
        }

        bool OnTimerTick()
        {
            if (_gameEnded) return false;
            FlashBoxView(sequence[_sequenceIndex]);
            _sequenceIndex++;
            _awaitingTaps = _sequenceIndex == sequence.Count;
            _sequenceIndex = _awaitingTaps ? 0 : _sequenceIndex;
            return !_awaitingTaps;
        }

        protected virtual void FlashBoxView(int index)
        {
            boxViews[index].Color = colors[index].WithLuminosity(OnLuminosity);
            Device.StartTimer(TimeSpan.FromMilliseconds(FlashDuration), () =>
            {
                if (_gameEnded) return false;
                boxViews[index].Color = colors[index].WithLuminosity(OffLuminosity);
                return false;
            });
        }

        protected void OnBoxViewTapped(object sender, EventArgs args)
        {
            if (_gameEnded)
                return;
            if (!_awaitingTaps)
            {
                EndGame();
                return;
            }


            BoxView tappedBoxView = (BoxView) sender;
            int index = Array.IndexOf(boxViews, tappedBoxView);

            if (index != sequence[_sequenceIndex])
            {
                EndGame();
                return;
            }

            FlashBoxView(index);
            _sequenceIndex++;

            _awaitingTaps = _sequenceIndex < sequence.Count;
            if (!_awaitingTaps)
                StartSequence();
        }

        protected virtual void EndGame()
        {
            _gameEnded = true;
            for (int index = 0; index < 4; index++) boxViews[index].Color = Color.Gray;
            startGameButton.Text = "Try again?";
            startGameButton.IsVisible = true;
        }
    }
}