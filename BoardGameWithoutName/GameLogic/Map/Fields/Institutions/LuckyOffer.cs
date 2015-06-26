﻿using GameLogic.Game;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLogic.Map.Fields.Institutions
{
    public class LuckyOffer : Offer
    {
        private Player player;
        private static Random rnd = new Random();

        internal LuckyOffer(Player player)
            : base("Lucky Field")
        {
            this.player = player;
        }

        public string CardMessage { get; private set; }

        public override void Accept()
        {
            if (this.IsValid)
            {
                this.IsValid = false;
                int cardNumber = rnd.Next(0, cards.Length);
                string[] cardInfo = cards[cardNumber].Split('*');
                this.CardMessage = cardInfo[0];
                int payAmount = int.Parse(cardInfo[1]);

                if (payAmount > 0)
                {
                    this.player.TakePayment(payAmount);
                }
                else
                {
                    this.player.Pay(payAmount * (-1));
                }
            }
        }

        private static string[] cards = new string[]
        {
            "You found $25 as you're walking on the street.*25",
            "It's not your best day. Your crashed your car and have to pay $150.*-150"
        };
    }
}