import { DatePipe } from '@angular/common';
import { Pipe, PipeTransform } from '@angular/core';
import { DtFormat } from './DtFormat';


@Pipe({
  name: 'DateTimeFormatPipe'
})
export class DateTimeFormatPipePipe extends DatePipe implements PipeTransform {

  transform(value: any) {

    value = super.transform(value, DtFormat.DATE_TIME_FMT);
    return value;

  }
}
