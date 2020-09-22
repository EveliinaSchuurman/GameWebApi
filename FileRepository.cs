/*using System;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Linq;


namespace GameWebApi{

    public class PlayerList{
        public List<Player>playerList = new List<Player>();
    }
    public class FileRepository : IRepository{

        string path = @"C:\Users\eveli\Documents\vs_code_web\GameWebApi\game_dev.txt";
        public async Task<Player> GetPlayer(Guid id){
            PlayerList players = await ReadFile();
            Player newPlayer = new Player();
            foreach(Player play in players.playerList){
                if(play.Id == id){
                    newPlayer = play;
                    break;
                }
            }
            return newPlayer;
        }
        public async Task<Player[]> GetAllPlayers(){
            PlayerList players = await ReadFile();
            return players.playerList.ToArray();
            }
        
        public async Task<Player> CreatePlayer(Player player){

            PlayerList players = await ReadFile();
            players.playerList.Add(player);
            File.WriteAllText(path, JsonConvert.SerializeObject(players));
            return player;
        }
        public async Task<Player> UpdatePlayer(Guid id, ModifiedPlayer player){
            PlayerList players = await ReadFile();
            Player modifiedPlayer = new Player();
            foreach(var play in players.playerList){
                if(play.Id == id){
                    play.Score = player.Score;
                    File.WriteAllText(path, JsonConvert.SerializeObject(players));
                    break;
                }
            }
            return modifiedPlayer;

        }
        public async Task<Player> DeletePlayer(Guid id){
            PlayerList players = await ReadFile();
            for(int i = 0; i < players.playerList.Count; i++){
                if(players.playerList[i].Id == id){
                    players.playerList.RemoveAt(i);
                    File.WriteAllText(path, JsonConvert.SerializeObject(players));
                    return null;
                }
            }
            return null;
        }

        public async Task<Item> CreateItem(Guid playerId, Item item)
        {
            return null;
        }
        public async Task<Item> GetItem(Guid playerId, Guid itemId)
        {
            return null;
        }
        public async Task<Item[]> GetAllItems(Guid playerId)
        {
            return null;
        }
        public async Task<Item> UpdateItem(Guid playerId, Item item)
        {
            return null;
        }
        public async Task<Item> DeleteItem(Guid playerId, Item item)
        {
            return null;
        }


         public async Task<PlayerList> ReadFile()
        {
            var players = new PlayerList();
            string json = await File.ReadAllTextAsync(path);
            //return JsonConvert.DeserializeObject<PlayerList>(json);

            if (File.ReadAllText(path).Length != 0)
            {
                return JsonConvert.DeserializeObject<PlayerList>(json);
            }

            return players;
        }

        public void WriteFile(String text)
        {
            File.WriteAllText(path, JsonConvert.SerializeObject(text));
        }

    }
}*/