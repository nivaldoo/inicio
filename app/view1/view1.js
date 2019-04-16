'use strict';

angular.module('myApp.view1', ['ngRoute', 'core.usuario'])

.config(['$routeProvider', function ($routeProvider) {
    $routeProvider.when('/view1', {
        templateUrl: 'view1/view1.html',
        controller: 'View1Ctrl'
    });
}])

.controller('View1Ctrl', ['Usuario', '$scope', '$http', function (Usuario, $scope, $http) {

    //######### FILTRO #########
    Usuario.get({ id: '270A9672-EDF3-4F32-891D-A3189A369CA5', nome: 'flavio', cpf: '013.361.605-35' }, function (data) {
        //$scope.Nome = data.Nome;
        //$scope.Nome = data[0].Nome;
        $scope.Usuarios = data;
    }, function (error) {
        console.log(error.data.ExceptionMessage);
    });

    //######### TODOS #########
    //Usuario.query(function (data) {
    //    $scope.Usuarios = data;
    //    console.log($scope.Usuarios);
    //});

    //######### APAGAR #########
    //Usuario.delete({ id: '58FFABFE-B45A-4737-8D0D-E7315C6CB9AD' }, function () {
    //    console.log('apagou');
    //}, function (error) {
    //    console.log(error.data.ExceptionMessage);
    //});

    //####### INSERIR #########
    //Usuario.save({ id: '58FFABFE-B45A-4737-8D0D-E7315C6CB9AD' }, function () {
    //    console.log('inseriu');
    //});

    //####### ATUALIZAR #########
    //Usuario.update({ _id: '58FFABFE-B45A-4737-8D0D-E7315C6CB9AD' }, function () {
    //    console.log('atualizou');
    //});

    //####### PERSONALIZADO #########
    //$http
    //.post('api/Usuario/Outro/', { Nome: 'teste', teste: 'qua' } )
    //.then(function (data) { 
    //    console.log(data);
    //});
    // Não consegui fazer funcionar em harmonia. Quando configurei o App_Start, deu paLLLL

}]);