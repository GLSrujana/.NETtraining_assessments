import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';

import { CalculatorService } from '../../services/calculator';
import { MessageService } from '../../services/message';

@Component({
  selector: 'app-service-demo',
  standalone: true,
  imports: [FormsModule, CommonModule],
  templateUrl: './service-demo.html',
  styleUrls: ['./service-demo.css']
})
export class ServiceDemoComponent {

  num1 = 0;
  num2 = 0;
  result = 0;

  message = '';
  messages: string[] = [];

  constructor(
    private calculatorService: CalculatorService,
    private messageService: MessageService
  ) {}

  // Calculator Service usage
  add() {
    this.result = this.calculatorService.add(this.num1, this.num2);
  }

  subtract() {
    this.result = this.calculatorService.subtract(this.num1, this.num2);
  }

  // Message Service usage
  addMessage() {
    if (this.message.trim()) {
      this.messageService.addData(this.message);
      this.messages = this.messageService.getData();
      this.message = '';
    }
  }
}
