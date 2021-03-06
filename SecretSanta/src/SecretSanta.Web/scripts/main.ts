import '../styles/site.css';

import 'alpinejs';
import axios from 'axios';

import { library, dom } from "@fortawesome/fontawesome-svg-core";
import { fas, faThList } from '@fortawesome/free-solid-svg-icons';
import { far } from '@fortawesome/free-regular-svg-icons';
import { fab } from '@fortawesome/free-brands-svg-icons';

import { Group, GroupsClient, User, UsersClient, Gift, GiftsClient } from '../Api/SecretSanta.Api.Client.g';

library.add(fas, far, fab);
dom.watch();

declare var apiHost : string;

export function setupNav() {
    return {
        toggleMenu() {
            var headerNav = document.getElementById('headerNav');
            if (headerNav) {
                if (headerNav.classList.contains('hidden')) {
                    headerNav.classList.remove('hidden');
                } else {
                    headerNav.classList.add('hidden');
                }
            }
        }
    }
}

export function setupUsers() {
    return {
        users: [] as User[],
        async mounted() {
            await this.loadUsers();
        },
        async deleteUser(currentUser: User) {
            if (confirm(`Are you sure you want to delete ${currentUser.firstName} ${currentUser.lastName}?`)) {
                var client = new UsersClient(apiHost);
                await client.delete(currentUser.id);
                await this.loadUsers();
            }
        },
        async loadUsers() {
            try {
                var client = new UsersClient(`${apiHost}`);
                this.users = await client.getAll() || [];
            } catch (error) {
                console.log(error);
            }
        }
    }
}

export function createOrUpdateUser(){
    return{
        user: {} as User,
        async create(){
            try {
                const response = await axios.get(`${apiHost}/api/users`)
                //grabbing the max id if we don't do this we will always be replacing user 0
                let maxId:number = 0;

                for(let k = 1; k < response.data.length; k++)
                {
                    if(response.data[k].id > maxId){
                        maxId = response.data[k].id;
                    }
                }
                this.user.id = maxId +1;
                await axios.post(`${apiHost}/api/users`, this.user);
                window.location.href = "/users";
            }catch (error){
                console.log(error);
            }
        },
        async update(){
            try{
                await axios.put(`${apiHost}/api/users/${this.user.id}`, this.user);
                window.location.href = "/users";
            }catch(error){
                console.log(error);
            }
        },

        async loadData(){
            const pathnameSplit = window.location.pathname.split('/');
            const id = pathnameSplit[pathnameSplit.length-1];
            try{
                const response = await axios.get(`${apiHost}/api/users/${id}`)
                this.user = response.data;
            } catch (error) {
                console.log(error);
            }
        }
    }
}

export function setupGroups() {
    return {
        groups: [] as Group[],

        async mounted() {
            await this.loadGroups();
        },
        async deleteGroup(currentGroup: Group) {
            if (confirm(`Are you sure you want to delete ${currentGroup.name}?`)) {
                var client = new GroupsClient(apiHost);
                await client.delete(currentGroup.id);
                await this.loadGroups();
            }
        },
        async loadGroups() {
            try {
                var client = new GroupsClient(`${apiHost}`);
                this.groups = await client.getAll() || [];
            } catch (error) {
                console.log(error);
            }
        }
    }
}

export function createOrUpdateGroup() {
    return {
        group: {} as Group,
        allUsers: [] as User[],
        selectedUserId: 0,
        isEditing: false,
        generationError: "",

        async create() {
            try {
                const client = new GroupsClient(apiHost);
                await client.post(this.group);
                window.location.href = '/groups';
            } catch (error) {
                console.log(error);
            }
        },
        edit() {
            this.isEditing = true;
        },
        async update() {
            try {
                const client = new GroupsClient(apiHost);
                await client.put(this.group.id, this.group);
                this.isEditing = false;
                await this.loadGroup();
            } catch (error) {
                console.log(error);
            }
        },
        async loadData() {
            await this.loadGroup();
            await this.loadUsers();
        },
        async loadGroup() {
            const pathnameSplit = window.location.pathname.split('/');
            const id = pathnameSplit[pathnameSplit.length - 1];
            try {
                const client = new GroupsClient(apiHost);
                this.group = await client.get(+id);
            } catch (error) {
                console.log(error);
            }
        },
        async loadUsers() {
            try {
                var client = new UsersClient(apiHost);
                this.allUsers = await client.getAll() || [];
                var index = this.allUsers.findIndex(x => true);
                if (index >= 0) {
                    this.selectedUserId = this.allUsers[index].id;
                }
            } catch (error) {
                console.log(error);
            }
        },
        async removeFromGroup(currentGroup: Group, user: User) {
            if (confirm(`Are you sure you want to remove ${user.firstName} ${user.lastName} from ${currentGroup.name}?`)) {
                try {
                    var client = new GroupsClient(apiHost);
                    await client.remove(currentGroup.id, user.id);
                } catch (error) {
                    console.log(error);
                }
                await this.loadGroup();
            }
        },
        async addToGroup(currentGroupId: number) {
            if (this.selectedUserId <= 0) return;
            try {
                var client = new GroupsClient(apiHost);
                await client.add(currentGroupId, this.selectedUserId);
            } catch (error) {
                console.log(error);
            }
            await this.loadGroup();
        },
        async generateAssignments(currentGroupId:number)
        {
            try{
                var client = new GroupsClient(apiHost);
                await client.generateAssignments(currentGroupId);
                this.generationError="";
            }catch(error){
                console.log(error);
                this.generationError = error;
            }
            await this.loadGroup();
        },
        getAssignment(user:User) :string
        {
            var receiver: string = "Not assigned";
            
            try{
                this.group.assignments.forEach(i =>{
                    if(i.giver?.id == user.id && i.giver.firstName == user.firstName && i.giver.lastName == user.lastName){
                        receiver = `${i.receiver?.firstName} ${i.receiver?.lastName}`
                    }
                });
            }catch (error)
            {
                console.log(error);
                this.generationError = error;
                receiver = error;
            }
            
            return receiver;
        }
    }
}