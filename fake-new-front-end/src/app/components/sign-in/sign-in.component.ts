import { DOCUMENT } from '@angular/common';
import { Component, Inject, NgZone, OnInit, Renderer2 } from '@angular/core';
import { Meta } from '@angular/platform-browser';

@Component({
  selector: 'app-sign-in',
  templateUrl: './sign-in.component.html',
  styleUrls: ['./sign-in.component.css']
})
export class SignInComponent implements OnInit {

  constructor(private metaService: Meta, 
    @Inject(DOCUMENT) private doc : Document,
    private renderer: Renderer2,
    ngZone : NgZone) { 
    window['onSignIn'] = user => ngZone.run(
      () => {
        this.afterSignUp(user);
      }
    );
  }

  ngOnInit(): void {
    // this.metaService.addTags([
    //   {name: 'google-signin-client_id',
    //   content: '1002279406968-rfqbf903rkhdtcosaat3m4vt3dnk96tm.apps.googleusercontent.com'}
    // ]);

    // let script = this.renderer.createElement('script');
    // script.src = "https://apis.google.com/js/platform.js";
    // script.defer = true;
    // script.async = true;
    // this.renderer.appendChild(document.body, script); 
  }

  afterSignUp(googleUser){
    console.log(googleUser);
  }
}
