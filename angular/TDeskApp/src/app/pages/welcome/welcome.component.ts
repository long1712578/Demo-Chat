import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Message } from 'src/app/modal/message';
import { AuthSevice } from 'src/app/services/auth-sevice.service';
import { ChatService } from 'src/app/services/chat.service';
import { SocketService } from 'src/app/services/socket.service';

@Component({
  selector: 'app-welcome',
  templateUrl: './welcome.component.html',
  styleUrls: ['./welcome.component.css']
})
export class WelcomeComponent implements OnInit {
  // tslint:disable-next-line:no-inferrable-types
  page: number = 1;
  isCollapsed = false;
  listMessage: Message[] = [];
  public isVideoCallAccepted: boolean = false;
  public callingInfo = { name: "", content: "", type: "" };
  public userType: string;
  isVideoCall = false;
  constructor(
    private chatService: ChatService,private socketService: SocketService) { }

  ngOnInit(): void {
    this.getMessage();
    this.OnVideoCallRequest();
    this.OnVideoCallAccepted();
    this.OnVideoCallRejected();
  }
  // tslint:disable-next-line:typedef get list message
  getMessage() {
    this.chatService.getMessage().subscribe(res => {
      this.listMessage = res;
      console.log('list message', this.listMessage);
    });
  }
  // tslint:disable-next-line:typedef scroll message
  onScroll() {
    console.log('Scrolled');
    this.page = this.page + 1;
    this.getMessage();
  }
  video(callee: any): void {
    //this.isVideoCall = true;
    this.socketService.VideoCallRequest('name',callee.id);
    //this.callee = callee;
    this.callingInfo.name = callee.username;
    this.callingInfo.content = "Dialing....";
    this.callingInfo.type = "dialer";
    this.isVideoCall = true;
    //window.open('/video', '', 'width:70%,height:60%,align: center');
  }
  AcceptVideoCall(){
    this.isVideoCall = false;
    window.open('/video', '', 'width:70%,height:60%,align: center');
  }
  RejectVideoCall(){
    this.isVideoCall = false;
  }

  handleCancel(): void {
    console.log('Button cancel clicked!');
    this.isVideoCall = false;
  }
  OnVideoCallRequest(){
    this.socketService.OnVideoCallRequest()
        .subscribe(data=>{
          this.callingInfo.name = data.fromname;
                this.callingInfo.content = "Calling....";
                this.callingInfo.type = "receiver";
                this.isVideoCall = true;
        })
  }
  OnVideoCallAccepted(){
    this.socketService.OnVideoCallAccepted()
        .subscribe(data=>{
                //var calee = this.listFriend.find(a => a.username == this.callingInfo.name);
                this.userType = "dialer";
                //this.caller = calee.id;
                this.isVideoCallAccepted = true;
                //this.socketService.BusyNow();
                this.handleCancel();
        })
  }
  OnVideoCallRejected(){
    this.socketService
            .OnVideoCallRejected()
            .subscribe(data => {
                this.callingInfo.content = "Call Rejected ..";
                setTimeout(() => {
                    this.handleCancel();
                }, 1000);
            });
  }
}
