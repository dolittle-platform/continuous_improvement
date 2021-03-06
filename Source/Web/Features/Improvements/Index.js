/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Dolittle. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
import { observable, containerless } from 'aurelia-framework';
import { QueryCoordinator } from '@dolittle/queries';
import { ImprovementsForImprovable } from './ImprovementsForImprovable';
import { StepsForImprovement } from './StepsForImprovement';
import { inject } from 'aurelia-dependency-injection';

@containerless()
@inject(QueryCoordinator)
export class Improvements {
    #queryCoordinator;
    #router;

    improvements = [];
    @observable selectedVersion;

    steps = [];

    #firstRun = true;
    improvable;

    constructor(queryCoordinator) {
        this.#queryCoordinator = queryCoordinator;
    }

    async activate(params, routeConfig, navigationInstruction) {
        let query = new ImprovementsForImprovable();
        query.improvable = params.improvable;
        this.improvable = params.improvable;

        this.selectedVersion = navigationInstruction.plan.default.childNavigationInstruction.params.version;
        this.#firstRun = false;
        let result = await this.#queryCoordinator.execute(query);
        

        this.improvements = result.items;

        if( !this.selectedVersion ) {
            this.selecedVersion = result.items[0].version;
        }

        this.populateSteps();
    }

    populateSteps() {
        let query = new StepsForImprovement();
        query.improvable = this.improvable;
        query.version = this.selectedVersion;

        this.#queryCoordinator.execute(query).then(result => {
            this.steps = result.items;
        });
    }

    configureRouter(config, router) {
        this.#router = router;

        config.title = 'Improvement details';
        config.map([{
            route: ['', ':version/:step'],
            name: 'Details',
            moduleId: PLATFORM.moduleName('Improvements/ImprovementDetails')
        }]);
    }

    async selectedVersionChanged(version) {
        if (this.#firstRun ) return;
        this.populateSteps();
        this.#router.navigate(`${version}/1`);
    }
}