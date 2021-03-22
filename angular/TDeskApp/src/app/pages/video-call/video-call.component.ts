import { ChangeDetectorRef, Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { Router } from '@angular/router';
import { SocketService } from 'src/app/services/socket.service';

@Component({
  selector: 'app-video-call',
  templateUrl: './video-call.component.html',
  styleUrls: ['./video-call.component.css']
})
export class VideoCallComponent implements OnInit {
  public peerConnection: any;
  public localStream: any;
  public remoteStream: any;
  public offerOptions = {
    offerToReceiveAudio: true,
    offerToReceiveVideo: true
  };
  public loggedUserName;

  public caller;
  @Input('caller')
  public set setCaller(_caller) {
    this.changeDetector.detectChanges();
    this.caller = _caller;
  }

  public userType;
  @Input('userType')
  public set setUserType(_type) {
    this.ngOnInit();
    if (_type == 'dialer') {
      setTimeout(() => {
        this.changeDetector.detectChanges();
        this.Call();
      }, 2000);
    }
  }

  @Output('callback')
  callback: EventEmitter<Object> = new EventEmitter<Object>();
  constructor(private socketService: SocketService, private router: Router,
    private changeDetector: ChangeDetectorRef) { }

  ngOnInit(): void {
    this.GetLocalStream();
    this.loggedUserName = sessionStorage.getItem("username");
    this.socketService
      .ReceiveCallRequest()
      .subscribe(data => {
        this.OnCallRequestReceived(data.data);
      });
    this.OnCallEnded();
  }
  OnCallEnded() {
    this.socketService
      .OnVideoCallEnded()
      .subscribe(data => {

      });
  }
  OnCallRequestReceived(data) {
    if (data.desc) {
      var descrip = new RTCSessionDescription(data.desc);
      if (descrip.type == "offer") {
        this.SetConnection();
        this.OnCallOffer(descrip);
      } else if (descrip.type == "answer") {
        this.OnCallAnswer(descrip);
      } else {
        console.log("Unsupported SDP type!!");
      }
    } else if (data.candidate) {
      var candidate = new RTCIceCandidate(data.candidate);
      this.peerConnection.addIceCandidate(candidate).catch(err => console.log(err));
    }
  }
  OnCallOffer(descrip) {
    //callee receives the offer sets remote description 
    this.peerConnection.setRemoteDescription(descrip).then(
      () => {
        this.OnSetRemoteSuccess(this.peerConnection);
      },
    );
  }
  OnSetRemoteSuccess(val) {
    //callee creates answer
    this.peerConnection.createAnswer().then(
      this.OnCreateAnswerSuccess.bind(this),
      this.OnCreateSessionDescriptionError.bind(this)
    );
  }
  OnCreateAnswerSuccess(event) {
    //callee sets local description
    this.peerConnection.setLocalDescription(new RTCSessionDescription(event)).then(
      () => {
        //callee send the description to caller */
        this.socketService.SendCallRequest(this.peerConnection.localDescription, 'desc', this.caller);
        // this.ShowSuccess("create answer /n=>success");
      }
    );
  }
  OnCallAnswer(descrip) {

    this.peerConnection.setRemoteDescription(new RTCSessionDescription(descrip))
      .then(() => console.log('Succesfully set remote description')).catch(err => { console.log(err); });
  }
  //Get stream
  GetLocalStream() {
    navigator.mediaDevices.getUserMedia({
      video: true,
      audio: true
    }).then(this.GotLocalStream.bind(this))
      .then(this.GotDevices.bind(this))
      .catch(this.HandleDeviceError.bind(this));
  }
  GotLocalStream(stream) {
    var lv = document.getElementById('local-video') as HTMLVideoElement;
    lv.srcObject = stream;
    lv.controls = false;
    lv.muted = true;
    lv.volume = 0;
    this.localStream = stream;
    console.log("local stream id => " + stream.id);

  }
  GotDevices(deviceInfos) {
    var flagMic = false;
    var flagSpeaker = false;
    var flagWebCam = false;
    for (let i = 0; i !== deviceInfos.length; ++i) {
      const deviceInfo = deviceInfos[i];
      if (deviceInfo.kind == 'audioinput') {
        flagMic = true;
      }
      if (deviceInfo.kind == 'audiooutput') {
        flagSpeaker = true;
      }
      if (deviceInfo.kind == 'videoinput') {
        flagWebCam = true;
      }
    }
    var msg = '';
    if (!flagMic) {
      msg += 'microphone ';
    }
    if (!flagSpeaker) {
      msg += 'speaker ';
    }
    if (!flagWebCam) {
      msg += 'webcam ';
    }
    if (msg != '') {
      alert(msg + "not found!");
    }
  }

  HandleDeviceError(error) {
    if (error.name == "NotFoundError" || error.name == "DevicesNotFoundError") {
      alert("webcam or mic not connected to your system");
    }
    else if (error.name == "NotReadableError" || error.name == "TrackStartError") {
      alert("webcam or mic already in use by another application");
    } else if (error.name == "OverconstrainedError" || error.name == "ConstraintNotSatisfiedError") {
      alert("webcam or mic not supported!");
    } else if (error.name == "NotAllowedError" || error.name == "PermissionDeniedError") {
      alert("Access denied for accessing webcam or mic!");
    } else if (error.name == "MediaStreamError" || error.name == "TypeError") {
      console.log("empty constraints object");
    } else if (error.name == "PermissionDismissedError") {
      alert("Permission is dismissed for access webcam or mic");
    }
    console.log('navigator.MediaDevices.getUserMedia error: ', error.message, error.name);
  }

  EndCall() {
    this.socketService.EndVideoCall(this.loggedUserName, this.caller, 'username');
  }

  Call() {
    //Set connection
    this.SetConnection();
    //caller creates offer
    this.peerConnection.onnegotiationneeded = async () => {
      try {
        this.peerConnection.createOffer(this.offerOptions)
          .then(
            //caller sets localDescription
            this.OnCreateOfferSuccess.bind(this),
            this.OnCreateSessionDescriptionError.bind(this));
      } catch (err) {
        console.error(err);
      }
    };
  }
  OnCreateOfferSuccess(event) {
    // caller sets localDescription
    this.peerConnection.setLocalDescription(new RTCSessionDescription(event)).then(
      () => {
        //caller sends the description to the callee (type and sdp)
        this.socketService.SendCallRequest(this.peerConnection.localDescription, 'desc', this.caller);
        //this.ShowSuccess('created offer /nlocal description set /n=>Success');
      },
    );
  }
  //Set connection
  SetConnection() {
    //on both side
    this.peerConnection = new RTCPeerConnection();
    var iceServerConfig = {
      iceServers: [{
        urls: ["stun:bturn1.xirsys1221.com"]
      }, {
        username: "9hiaOVYRRn31s_Lv2sGS-iGgtEKg5_3SVWfeEZyO-4GWtKxUv0sCxQVNGkxlk-zBAAAAAF0sGiFhamF5cGF0aWw=",
        credential: "04f626c0-a6c8-11e9-8ad1-26d3ed601a80",
        urls: [
          "turn:bturn1.xirsys.com:80?transport=udp",
          "turn:bturn1.xirsys.com:3478?transport=udp",
          "turn:bturn1.xirsys.com:80?transport=tcp",
          "turn:bturn1.xirsys.com:3478?transport=tcp",
          "turns:bturn1.xirsys.com:443?transport=tcp",
          "turns:bturn1.xirsys.com:5349?transport=tcp"
        ]
      }]
    };

    this.peerConnection.setConfiguration(iceServerConfig);

    this.localStream.getTracks().forEach(track => {
      this.peerConnection.addTrack(track, this.localStream);
    });
    //this.peerConnection.addStream(this.localStream);
    this.peerConnection.onicecandidate = e => {
      this.OnIceCandidate(this.peerConnection, e);
    };
    this.peerConnection.ontrack = (event) => {
      this.GotRemoteStream(event.streams[0]);
    };
    this.peerConnection.oniceconnectionstatechange = e => {
      this.OnIceStateChange(this.peerConnection, e);
    };
  }

  OnIceCandidate(conn, event) {
    if (event.candidate) {
      // Send the candidate to the remote peer
      var candi = new RTCIceCandidate(event.candidate);
      this.socketService.SendCallRequest(candi, 'candidate', this.caller);
    } else {
      // All ICE candidates have been sent
      console.log("All ICE candidates have been sent");
    }
  }

  OnIceStateChange(peerConn, event) {
    if (peerConn) {
      console.log('ICE state change event: ', event);
    }
  }

  GotRemoteStream(stream) {
    var lv = document.getElementById('remote-video') as HTMLVideoElement;
    lv.srcObject = stream;
  }

  OnCreateSessionDescriptionError(event) {
  }
}