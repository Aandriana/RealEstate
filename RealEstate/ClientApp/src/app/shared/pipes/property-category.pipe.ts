import {Pipe, PipeTransform} from '@angular/core';
export const categories = {
  0 : 'Flat',
  1: 'House',
  2 : 'Сortege',
};
@Pipe({
  name: 'propertyCategory'
})
export class PropertyCategoryPipe implements PipeTransform {
  transform(category: number): string {
    return categories[category];
  }
}
