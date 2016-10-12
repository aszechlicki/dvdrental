/// <binding BeforeBuild='copyfiles' />
/*
This file in the main entry point for defining Gulp tasks and using Gulp plugins.
Click here to learn more. http://go.microsoft.com/fwlink/?LinkId=518007
*/

var gulp = require('gulp');

gulp.task('default', function () {
    // place code for your default task here
});

gulp.task('copyfiles', function () {
    gulp.src('./node_modules/angular/angular.min.js').pipe(gulp.dest('./wwwroot/libs/angular'));
    gulp.src('./node_modules/angular-route/angular-route.min.js').pipe(gulp.dest('./wwwroot/libs/angular'));
    gulp.src('./node_modules/angular-resource/angular-resource.min.js').pipe(gulp.dest('./wwwroot/libs/angular'));
    gulp.src('./node_modules/bootstrap/dist/**').pipe(gulp.dest('./wwwroot/libs/bootstrap'));
    gulp.src('./node_modules/jquery/dist/jquery.min.js').pipe(gulp.dest('./wwwroot/libs/jquery'));
});
