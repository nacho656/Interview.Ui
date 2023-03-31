import { createApp, defineAsyncComponent } from 'vue';


var app = createApp({
    components: {
        MediaModal: defineAsyncComponent(() => import("./add.media.modal.vue"))
    },
    data() {
        return {
            data: [],            
            isAddModalVisible: false
        };
    },
    methods: {
        showModal: function () {
            this.isAddModalVisible = true;            
        },
        load() {
            //Todo: Filter By Genre
            fetch("/api/media/getmedia")
                .then((rsp) => {
                    if (rsp.ok)
                        return rsp.json();
                })
                .then((data) => {
                    this.data = data;
                });
        }
        //Todo: Load Genre list
    },
    mounted() {
    }
});

app.mount("#app")