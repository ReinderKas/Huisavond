import { CommonModule } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { Player } from '../../../models/player';

@Component({
  selector: 'app-onevone',
  standalone: true,
  imports: [
    FormsModule,
    CommonModule
  ],
  templateUrl: './onevone.component.html',
  styleUrl: './onevone.component.css'
})
export class OnevoneComponent implements OnInit {
  players: Player[] = [];

  ngOnInit(): void {
      this.initData();
  }

  async initData(){
    const response =  await fetch(`https://localhost:5104/players`, {
      method: 'GET',
    });

    let playersRespo = await response.json();
    this.players = playersRespo;
  }

  async selectPlayer(player: Player, success: boolean){
    await fetch(`https://localhost:5104/onevone?name=${player.name}&winner=${success}`, {method: 'POST',})
    this.initData();
    
    if (!success) {
      let response2 = await fetch(`https://localhost:5104/drinkingBuddy?name=${player.name}`, {method: 'PUT',})
      this.initData();

      let playersRespo = await response2.text();
      if (playersRespo.length > 0){
        alert(playersRespo);
      }
    } 
  }


  startTimer(){
    window.open('https://www.google.com/search?q=countdown+timer+10+minutes&sca_esv=0bc43c4c8dd2597c&sca_upv=1&sxsrf=ADLYWIIXvxXxKZ5mQfDFXMwxsKEEBmIwAg%3A1719322878586&ei=_sh6ZuyjI_-Xi-gPvPey0A8&ved=0ahUKEwjsmrrr8PaGAxX_ywIHHby7DPoQ4dUDCBA&uact=5&oq=countdown+timer+10+minutes&gs_lp=Egxnd3Mtd2l6LXNlcnAiGmNvdW50ZG93biB0aW1lciAxMCBtaW51dGVzMgsQABiABBiRAhiKBTIFEAAYgAQyCxAAGIAEGJECGIoFMgsQABiABBiRAhiKBTILEAAYgAQYkQIYigUyCxAAGIAEGJECGIoFMgUQABiABDIFEAAYgAQyBRAAGIAEMgYQABgWGB5I5QhQAFijBXAAeACQAQCYAUWgAX2qAQEyuAEDyAEA-AEBmAICoAKCAcICBBAhGAqYAwCSBwEyoAewCQ&sclient=gws-wiz-serp', '_blank')?.focus();
  }
}
