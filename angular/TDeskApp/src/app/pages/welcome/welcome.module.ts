import { NgModule } from '@angular/core';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { DemoNgZorroAntdModule } from 'src/app/Shared/ng-zorro-antd.module';

import { WelcomeRoutingModule } from './welcome-routing.module';

import { WelcomeComponent } from './welcome.component';
import { ScrollingModule} from '@angular/cdk/scrolling';
import { InfiniteScrollModule } from 'ngx-infinite-scroll';
import { CommonModule } from '@angular/common';

@NgModule({
  imports: [WelcomeRoutingModule, DemoNgZorroAntdModule, NgbModule, ScrollingModule, InfiniteScrollModule, CommonModule ],
  declarations: [WelcomeComponent],
  exports: [WelcomeComponent]
})
export class WelcomeModule { }
