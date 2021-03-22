import { Injectable } from '@angular/core';
import { Observable, Subscriber } from 'rxjs';
import * as io from 'socket.io-client';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class SocketService {
  socketUrl = environment.apiUrl.socketUrl;
  socket: any;

  constructor() {
    this.socket = io(this.socketUrl);
  }

  /**
   * @description listen data from event
   * @param eventName name of event
   * @returns Observable of data
   */
  listen(eventName: string): Observable<any> {
    return new Observable((subscriber) => {
      this.socket.on(eventName, (data: any) => {
        subscriber.next(data);
      });
    });
  }
  /**
   * @description send request of call
   * @param val value 
   * @param type type of call
   * @param uid id of recieve 
   * @returns void
   */
  public SendCallRequest(val, type, uid) {
    var data;
    if (type == 'desc') {
      data = {
        toid: uid,
        desc: val
      }
    } else {
      data = {
        toid: uid,
        candidate: val
      }
    }
    this.socket.emit('call-request', data);
  }
  /**
   * @description revive request of call 
   * @returns Observable of data
   */
  public OnVideoCallRequest() {
    return Observable.create((observer) => {
      this.socket.on('video-call', (data) => {
        observer.next(data);
      });
    });
  }
  /**
   * @description revive video call accept of call 
   * @returns Observable of data
   */
  public OnVideoCallAccepted() {
    return Observable.create((observer) => {
      this.socket.on('video-call-accept', (data) => {
        observer.next(data);
      });
    });
  }
  /**
   * @description revive video call reject of call 
   * @returns Observable of data
   */
  public OnVideoCallRejected() {
    return Observable.create((observer) => {
      this.socket.on('video-call-reject', (data) => {
        observer.next(data);
      });
    });
  }
  /**
   * @description send event of call
   * @param from name of sender
   * @param toid id of receiver
   * @returns void
   */
  public VideoCallRequest(from, to) {
    this.socket.emit('video-call', {
      fromname: from,
      toid: to
    });
  }
  /**
   * @description revive video call request of call 
   * @returns Observable of data
   */
  public ReceiveCallRequest() {
    return Observable.create((observer) => {
      this.socket.on('call-request', (data) => {
        observer.next(data);
      });
    });
  }
  /**
   * @description event get list busy user and get video call ended
   * @returns Observable of data
   */
  public OnVideoCallEnded() {
    this.socket.emit('get-busy-user');
    return Observable.create((observer) => {
      this.socket.on('video-call-ended', (data) => {
        observer.next(data);
      });
    });
  }
  /**
   * @description send event of end call
   * @param from name of sender
   * @param toid id of receiver
   * @param toname name of receiver
   * @returns void
   */
  public EndVideoCall(from, to, toname) {
    this.socket.emit('end-video-call', {
      fromname: from,
      toid: to,
      toname: toname
    });
  }
}
