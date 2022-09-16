using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RockPaperScissorTest.Models
{
    [Serializable()]
    public class Results
    {
        #region Properties

        public Choice PlayerOption { get; set; }
        public Choice BotOption { get; set; }
        public int Win { get; set; }
        public int Lose { get; set; }
        public int Draw { get; set; }

        #endregion

        #region Functions
        //public Results(string playerOption, string comOption, int win, int lose, int draw)
        //{
        //    this.PlayerOption = playerOption;
        //    this.ComOption = comOption;
        //    this.Win = win;
        //    this.Lose = lose;
        //    this.Draw = draw;
        //}
        #endregion
    }


}