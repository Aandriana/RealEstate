import {Pipe, PipeTransform} from '@angular/core';
export const statuses = {
  0 : 'Frozen',
  1: 'Looking for agent',
  2 : 'Found agent',
  3: 'Sold'
};
@Pipe({
  name: 'propertyStatus'
})
export class PropertyStatusPipe implements PipeTransform {
  transform(status: number): string {
    return statuses[status];
  }
}
