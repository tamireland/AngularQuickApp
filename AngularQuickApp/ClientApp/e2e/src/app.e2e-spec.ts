// =============================
// Email: info@ebenmonney.com
// www.ebenmonney.com/templates
// =============================

import { AppPage } from './app.po';

describe('AngularQuickApp App', () => {
    let page: AppPage;

    beforeEach(() => {
        page = new AppPage();
    });

    it('should display application title: AngularQuickApp', () => {
        page.navigateTo();
        expect(page.getAppTitle()).toEqual('AngularQuickApp');
    });
});
