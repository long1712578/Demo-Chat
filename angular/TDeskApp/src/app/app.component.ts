import { Component, OnInit } from '@angular/core';
import { SocketService } from './services/socket.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit{

  isVisible = false;
  isShowChat = false;
  constructor(private socketService: SocketService){
  }

  ngOnInit(): void {
    this.socketService.listen('lan').subscribe(data => {
      console.log(data);
    }) ;
  }

  showModal(): void {
    this.isVisible = true;
  }
  handleCancel(): void {
    this.isVisible = false;
  }
  showOrHideChatBox(): void {
    this.isShowChat = true;
  }
}
