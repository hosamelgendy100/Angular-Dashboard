// import { AlertifyService } from '../services/alertify.service';
// import { Injectable } from '@angular/core';
// import { Resolve, Router, ActivatedRouteSnapshot} from '@angular/router';
// import { Observable, of } from 'rxjs';
// import { catchError } from 'rxjs/operators';


// @Injectable()
// export class ListsResolver implements Resolve<any[]> {
//     query = 'lions';
//     constructor( private router: Router, private imageService: ImageService, private alertify: AlertifyService) {}

//     resolve(route: ActivatedRouteSnapshot): Observable<any> {
//         return this.imageService.getPhotos(this.query).pipe(
//             catchError(error => {
//                 this.alertify.error('Problem retrieving data');
//                 this.router.navigate(['/home']);
//                 return of(null);
//             })
//         );
//     }
// }
