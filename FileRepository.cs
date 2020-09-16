using System;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Linq;

public class FileRepository : IRepository{

    public Task<Player> Get(Guid id){
        string jsonString;
        jsonString = File.ReadAllText("game_dev.txt");
        Player[] players = JsonConvert.DeserializeObject<Player[]>(jsonString);
         foreach(Player player in players){
                    if(player.Id == id){
                        return Task.FromResult(player);
                    }
         }

        return Task.FromResult(players[0]);//yes I'm aware this returns null
    }
    public Task<Player[]> GetAll(){
        string jsonString;
        jsonString = File.ReadAllText(@"game_dev.txt");
        Player[] players = JsonConvert.DeserializeObject<Player[]>(jsonString);
        return Task.FromResult(players);
        }
    public Task<Player> Create(Player player){
        string jsonString;
        jsonString = File.ReadAllText(@"game_dev.txt");
        Player[] players = JsonConvert.DeserializeObject<Player[]>(jsonString);
        players[(players.Count()) +1] = player;
        string jsonString2 = JsonConvert.SerializeObject(players);
        File.WriteAllText(@"game_dev.txt", jsonString2);
         return Task.FromResult(players[0]);
    }
    /*public Task<Player> Create(Player player){
        string jsonString;
        Player[] players;

        if(new FileInfo("game_dev.txt").Length == 0)
        {
            jsonString = JsonConvert.SerializeObject(player);
        } 
        else 
        {
            jsonString = File.ReadAllText("game_dev.txt");
            players = JsonConvert.DeserializeObject<Player[]>(jsonString);
            players.Concat(new Player[] { player }).ToArray();
            jsonString = JsonConvert.SerializeObject(players);
        }
        File.WriteAllText("game_dev.txt", jsonString);

        Console.WriteLine(jsonString);
        
        return Task.FromResult(player);
    }*/
    public Task<Player> Modify(Guid id, ModifiedPlayer player){
        string jsonString;
        jsonString = File.ReadAllText("game_dev.txt");
        Player[] players = JsonConvert.DeserializeObject<Player[]>(jsonString);
        foreach(Player _player in players){
            if(_player.Id == id){
                _player.Score = player.Score;
                string jsonString2 = JsonConvert.SerializeObject(_player);
                File.WriteAllText("game_dev.text", jsonString2);
                        
                return Task.FromResult(_player);
            }
         }
         return Task.FromResult(players[0]);
    }
    public Task<Player> Delete(Guid id){
        string jsonString;
        jsonString = File.ReadAllText("game_dev.txt");
        Player[] players = JsonConvert.DeserializeObject<Player[]>(jsonString);
        Player[] playersnew = new Player[players.Length -1];
        Player deletedPlayer = new Player();
        int i = 0;
        int j = 0;
        while(i < players.Length){
            if(players[i].Id != id){
                playersnew[j] = players[i];
                j++;
            }
            else {
                players[i] = deletedPlayer;
            }
            i++;
         }
         string jsonString2 = JsonConvert.SerializeObject(playersnew);
                File.WriteAllText("game_dev.text", jsonString2);
         return Task.FromResult(deletedPlayer);
    }
}