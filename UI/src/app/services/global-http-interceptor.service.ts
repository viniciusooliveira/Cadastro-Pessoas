import {Injectable} from "@angular/core";
import {HttpEvent, HttpHandler, HttpInterceptor, HttpRequest, HttpResponse, HttpErrorResponse} from '@angular/common/http';
import {Observable, of, throwError} from "rxjs";
import {catchError, map} from 'rxjs/operators';
import {Router} from '@angular/router';
import {ToastrService} from 'ngx-toastr';

@Injectable()
export class GlobalHttpInterceptorService implements HttpInterceptor {

  constructor(public router: Router, private toastr: ToastrService ) {
  }

  intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {

    return next.handle(req).pipe(
      catchError((error) => {
        if (error.status === 400 && error.error != null && error.error.errors != null) {
          let property = Object.keys(error.error.errors)[0];
          if (property != null && error.error.errors[property] != null && error.error.errors[property].length > 0){
            let e = error.error.errors[property][0];

            this.toastr.warning(e);
          }
        } else {
          this.toastr.error("Erro desconhecido.");
        }
        return throwError(error.message);
      })
    );
  }
}
