﻿using System.Collections.Generic;

namespace CCSblockchain.Models
{
    public class Block
    {
        private uint nextIndex;
        private long nextTimestamp;
        private string data;
        private string nextHash;
        private int difficulty;
        private int nonce;

        public uint Index { get; set; }
        public List<Transaction> Transactions { set; get; }
        public uint Difficulty { get; set; }
        public string PreviousBlockHash { get; set; }
        public string MinedBy { set; get; }
        
        public string BlockDataHash { get; set; } //Created Automatically using the var above

        //Assigned By Miners
        public long DateCreated { get; set; }
        public uint Nonce { set; get; }
        public string BlockHash { set; get; }

        public Block()
        {
            Index = 0;
            Transactions = null;
            Difficulty = 0;
            PreviousBlockHash = null;
            MinedBy = null;
            BlockDataHash = null;
            DateCreated = 0;
            Nonce = 0;
        }
        
        public Block(uint Index, 
                    List<Transaction> Transactions, 
                    uint Difficulty, 
                    string PreviousBlockHash,
                    string MinedBy,
                    string BlockDataHash,
                    long DateCreated,
                    uint Nonce)
        {
            this.Index = Index;
            this.Transactions = Transactions;
            this.Difficulty = Difficulty;
            this.PreviousBlockHash = PreviousBlockHash;
            this.MinedBy = MinedBy;
            this.BlockDataHash = BlockDataHash;
            this.DateCreated = DateCreated;
            this.Nonce = Nonce;
        }

        public Block(uint nextIndex, string BlockDataHash, long nextTimestamp, string data, string nextHash, int difficulty, int nonce)
        {
            this.nextIndex = nextIndex;
            this.BlockDataHash = BlockDataHash;
            this.nextTimestamp = nextTimestamp;
            this.data = data;
            this.nextHash = nextHash;
            this.difficulty = difficulty;
            this.nonce = nonce;
        }
    }
}
