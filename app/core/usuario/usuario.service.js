'use strict';

angular.
  module('core.usuario').
  factory('Usuario', ['$resource',
    function ($resource) {
    	return $resource('api/Usuario/:id', { id: '@_id' }, {
    		update: {
    			method: 'PUT'
    		},
    		get: {
    			isArray: true
    		}
    	});
    }
  ]);