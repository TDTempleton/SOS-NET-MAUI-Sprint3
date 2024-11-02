//using Android.Net.Wifi.Aware;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm;
using SOS_NET_MAUI.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOS_NET_MAUI.ViewModel
{
    public partial class SOSGamePageViewModel : ObservableObject
    {
        [ObservableProperty]
        private int _player1Point;

        [ObservableProperty]
        private int _player2Point;

        [ObservableProperty]
        private string _playerWinOrDrawTex = "";

        [ObservableProperty]
        // NEED TO FIX VVVVVVVVVVVV 
        [NotifyPropertyChangedFor(nameof(Player1BackgroundColor))]
        [NotifyPropertyChangedFor(nameof(Player2BackgroundColor))]

        private int _playerTurn = 0;

        public Color Player1BackgroundColor => PlayerTurn == 0 ? Colors.Red : Colors.White;

        public Color Player2BackgroundColor => PlayerTurn == 0 ? Colors.LightBlue : Colors.White;

        private bool _isAnyoneWin;

        List<int[]> WinPossibilities = new List<int[]>();
        public ObservableCollection<SOSModel> SOSList { get; set; } = new ObservableCollection<SOSModel>();
        public SOSGamePageViewModel()
        {
            SetupGameInfo();
        }

        private void SetupGameInfo()
           
        {
            WinPossibilities.Clear();

            // Horizontal check
            WinPossibilities.Add(new[] { 0, 1, 2 });
            WinPossibilities.Add(new[] { 3, 4, 5 });
            WinPossibilities.Add(new[] { 6, 7, 8 });

            // Vertical check
            WinPossibilities.Add(new[] { 0, 3, 6 });
            WinPossibilities.Add(new[] { 1, 4, 7 });
            WinPossibilities.Add(new[] { 2, 2, 8 });
            
            // Diagonal check
            WinPossibilities.Add(new[] { 0, 4, 8 });
            WinPossibilities.Add(new[] { 2, 4, 6 });

            // FINISH WIN VALUES ^^^^^^^^^^^^^^^^^^^

            SOSList.Clear();
            SOSList.Add(new SOSModel(0));
            SOSList.Add(new SOSModel(1));
            SOSList.Add(new SOSModel(2));
            SOSList.Add(new SOSModel(3));
            SOSList.Add(new SOSModel(4));
            SOSList.Add(new SOSModel(5));
            SOSList.Add(new SOSModel(6));
            SOSList.Add(new SOSModel(7));
            SOSList.Add(new SOSModel(8));
            SOSList.Add(new SOSModel(9));
            SOSList.Add(new SOSModel(10));
            SOSList.Add(new SOSModel(11));
            SOSList.Add(new SOSModel(12));
            SOSList.Add(new SOSModel(13));
            SOSList.Add(new SOSModel(14));
            SOSList.Add(new SOSModel(15));
            SOSList.Add(new SOSModel(16));
            SOSList.Add(new SOSModel(17));
            SOSList.Add(new SOSModel(18));
            SOSList.Add(new SOSModel(19));
            SOSList.Add(new SOSModel(20));
            SOSList.Add(new SOSModel(21));
            SOSList.Add(new SOSModel(22));
            SOSList.Add(new SOSModel(23));
            SOSList.Add(new SOSModel(24));
            SOSList.Add(new SOSModel(25));
            SOSList.Add(new SOSModel(26));
            SOSList.Add(new SOSModel(27));
            SOSList.Add(new SOSModel(28));
            SOSList.Add(new SOSModel(29));
            SOSList.Add(new SOSModel(30));
            SOSList.Add(new SOSModel(31));
            SOSList.Add(new SOSModel(32));
            SOSList.Add(new SOSModel(33));
            SOSList.Add(new SOSModel(34));
            SOSList.Add(new SOSModel(35));
            SOSList.Add(new SOSModel(36));
            SOSList.Add(new SOSModel(37));
            SOSList.Add(new SOSModel(38));
            SOSList.Add(new SOSModel(39));
            SOSList.Add(new SOSModel(40));
            SOSList.Add(new SOSModel(41));
            SOSList.Add(new SOSModel(42));
            SOSList.Add(new SOSModel(43));
            SOSList.Add(new SOSModel(44));
            SOSList.Add(new SOSModel(45));
            SOSList.Add(new SOSModel(46));
            SOSList.Add(new SOSModel(47));
            SOSList.Add(new SOSModel(48));
            SOSList.Add(new SOSModel(49));
            SOSList.Add(new SOSModel(50));
            SOSList.Add(new SOSModel(51));
            SOSList.Add(new SOSModel(52));
            SOSList.Add(new SOSModel(53));
            SOSList.Add(new SOSModel(54));
            SOSList.Add(new SOSModel(55));
            SOSList.Add(new SOSModel(56));
            SOSList.Add(new SOSModel(57));
            SOSList.Add(new SOSModel(58));
            SOSList.Add(new SOSModel(59));
            SOSList.Add(new SOSModel(60));
            SOSList.Add(new SOSModel(61));
            SOSList.Add(new SOSModel(62));
            SOSList.Add(new SOSModel(63));

            // Bind the 64 boxes in the game board grid to UI
        }
        [RelayCommand]
        public void RestartGame()
        {
            //clear SOSList & other
            _isAnyoneWin = false;
            //_playerWinOrDrawText = ;
            PlayerTurn = 0; // player 0 goes first
            SetupGameInfo();
        }

        // reference to Mvvm
        [RelayCommand]
        public void SelectedItem(SOSModel selectedItem) 
        {
            // after win validation
            if (!string.IsNullOrWhiteSpace(selectedItem.SelectedText) || _isAnyoneWin) return;

            // Set Player 1 and 2 "S" or "O"
            if (PlayerTurn == 0) 
            {
                selectedItem.SelectedText = "S"; // WAS Player 1
            }
            else
            {
                selectedItem.SelectedText = "O"; // WAS Player 2
            }
            // by default, player is null
            selectedItem.Player = PlayerTurn;
            //swap player turn
            PlayerTurn = PlayerTurn == 0 ? 1 : 0;

            // Determine Win or Draw
            CheckForWin();
        
        }

        private void CheckForWin() 
        {
            // Here match win value for each player
            var player1IndexList = SOSList.Where(f => f.Player == 0).Select(f => f.Index).ToList();
            var player2IndexList = SOSList.Where(f => f.Player == 1).Select(f => f.Index).ToList();

            string _playerWinOrDrawText = "";

            // Check player index list matching win possibilities

            if(player1IndexList.Count > 2 || player2IndexList.Count > 2)
            {
                foreach(var winPossibility in WinPossibilities)
                {
                    if (_isAnyoneWin) break;
                    int player1Count = 0;
                    int player2Count = 0;

                    // check for player 1 win
                    foreach(var index in player1IndexList)
                    {
                        if (winPossibility.Contains(index))
                        {
                            player1Count++;
                        }
                        if(player1Count == 3)
                        {
                            _player1Point++;
                            _playerWinOrDrawText = "Player 1 WINS!";
                            _isAnyoneWin = true;
                            break;
                        }
                    }

                    // check for player 2 win
                    foreach (var index in player2IndexList)
                    {
                        if (winPossibility.Contains(index))
                        {
                            player2Count++;
                        }
                        if (player2Count == 3)
                        {
                            _player2Point++; // add win to player 2 count for times they won
                            _isAnyoneWin = true;
                            _playerWinOrDrawText = "Player 2 WINS!";
                            break;
                        }
                    }
                    // set player win text in one observable property
                }

            }

            // test for draw of game
            // all frames have been selected with no winner
            if(SOSList.Count(f=> f.Player.HasValue)==64 && !_isAnyoneWin)
            {
                _playerWinOrDrawText = "DRAW!";
            }

        }
    }
}
