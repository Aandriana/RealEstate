import {Pipe, PipeTransform} from '@angular/core';
export const statuses = {
  0 : 'Offer to agent',
  1: 'Offer from agent',
  2 : 'Confirmed',
  3: 'Declined',
  4: 'Sold',
  5: 'Failed'
};
@Pipe({
  name: 'offerStatus'
})
export class OfferStatusPipe implements PipeTransform {
  transform(status: number): string {
    return statuses[status];
  }
}
