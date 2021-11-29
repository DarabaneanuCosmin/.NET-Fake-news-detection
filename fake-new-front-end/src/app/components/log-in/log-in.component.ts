import { DOCUMENT } from '@angular/common';
import { Component, Inject, NgZone, OnInit, Renderer2, ResolvedReflectiveFactory } from '@angular/core';
import { Meta } from '@angular/platform-browser';
import { CookieOptions, CookieOptionsProvider, CookieService, COOKIE_OPTIONS } from 'ngx-cookie';


@Component({
  selector: 'app-log-in',
  templateUrl: './log-in.component.html',
  styleUrls: ['./log-in.component.css'],
  providers: [CookieService]
})
export class LogInComponent implements OnInit {
  
  constructor(private metaService: Meta, 
    @Inject(DOCUMENT) private doc : Document,
    private renderer: Renderer2,
    ngZone : NgZone,
    private cookieService: CookieService,
    private cookieOptions: CookieOptionsProvider
    ) { 
    window['onSignIn'] = user => ngZone.run(
      () => {
        this.afterSignUp(user);
      }
    );

  }

  ngOnInit(): void {
    this.metaService.addTags([
      {name: 'google-signin-client_id',
      content: '1002279406968-rfqbf903rkhdtcosaat3m4vt3dnk96tm.apps.googleusercontent.com'}
    ]);

    let script = this.renderer.createElement('script');
    script.src = "https://apis.google.com/js/platform.js";
    
    script.defer = true;
    script.async = true;
    this.renderer.appendChild(this.doc.body, script); 

   // let cookieOption = { SameSite:"None"} as CookieOptions;
    //this.cookieService.put("G_AUTHUSER_H", "0", cookieOption);
    //console.log(this.cookieService.getAll());
  }



  afterSignUp(googleUser){
    console.log("da");
    console.log(googleUser);
  }
}
