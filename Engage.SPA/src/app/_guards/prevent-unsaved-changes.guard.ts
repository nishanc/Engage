import { Injectable } from '@angular/core';
import { CanDeactivate } from '@angular/router';
import { MemberEditComponent } from '../members/member-edit/member-edit.component';

@Injectable()
export class PreventUnsavedChange implements CanDeactivate <MemberEditComponent> {
    canDeactivate(component: MemberEditComponent){
        if (component.editForm.dirty){
            return confirm('Are sure you want to continue?, any unsaved changes will be lsot.');
        }
        return true;
    }
}
